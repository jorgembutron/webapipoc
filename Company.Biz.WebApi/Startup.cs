using AutoMapper;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.Infrastructure.Contexts;
using Company.Biz.Infrastructure.Repositories;
using Company.Biz.WebApi.Extensions;
using Company.Biz.WebApi.Filters;
using Company.Biz.WebApi.Middleware;
using Company.Services.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace Company.Biz.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            services.AddScoped<IPingRepository, PingRepository>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();

            string connection = configuration.GetConnectionString("Dev");

            services.AddDbContext<DummyDbContext>(options => options.UseSqlServer(connection));

            services.AddAutoMapper(GetType().Assembly);

            services.AddControllers();

            services.AddMvc(options => options.Filters.Add(typeof(ValidatorActionFilter)))
                    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

            //ToDo: Add response with 422 Unprocessable Entity Object Result

            services.AddSwagger();
        }

        /// <summary>
        /// his method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware(typeof(ExceptionHandlerMiddleware));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureSwagger(app);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Library API");
                setupAction.RoutePrefix = "";
            });
        }


    }
}
