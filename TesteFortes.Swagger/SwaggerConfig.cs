using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TesteFortes.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services) 
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Teste Fortes",
                    Version = "v1",
                    Description = "Teste realizado por Silvio Agostinho",
                    Contact = new OpenApiContact
                    {
                        Name = "Silvio Henrique Agostinho",
                        Email = "shagost@hotmail.com"
                    }
                });

                var xmlPath = Path.Combine("wwwroot", "api-doc.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = "documentation";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}