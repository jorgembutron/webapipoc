using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Company.Biz.WebApi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Libraray API",
                        Version = "1",
                        Description = "API to manage PINGs",
                        Contact = new OpenApiContact()
                        {

                        },
                        License = new OpenApiLicense()
                        {

                        }
                    });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsPath);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerTool(this IApplicationBuilder app)
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
