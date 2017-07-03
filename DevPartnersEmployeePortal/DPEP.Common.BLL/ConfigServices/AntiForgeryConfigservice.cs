using Microsoft.Extensions.DependencyInjection;

namespace DPEP.Common.BLL.ConfigServices
{
    public static class AntiForgeryConfigService
    {
        public static IServiceCollection RegisterAntiForgery(this IServiceCollection services)
        {

            services.AddAntiforgery(options => {

                options.HeaderName = "X-XSRF-TOKEN";
            });

            return services;
        }
    }
}