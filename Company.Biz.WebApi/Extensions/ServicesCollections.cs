using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Company.Biz.WebApi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServicesCollections
    {
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
    }
}
