using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DPEP.Common.BLL.ConfigServices
{
    public static class SwaggerConfigService
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "DevPartners Employee Portal",
                    Version = "June 2017"
                });
            });
        }

        public static IApplicationBuilder RegisterSwagger(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();

            applicationBuilder.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                c.RoutePrefix = "docs/swagger";
            });
            return applicationBuilder;
        }

    }
}
