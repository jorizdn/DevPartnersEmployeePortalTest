using DPEP.Common.BLL.Helpers;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.BLL.Methods;
using DPEP.Common.BLL.Repositories;
using DPEP.Common.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DPEP.Common.BLL.ConfigServices
{
    public static class DInjectionConfigServices
    {
        public static IServiceCollection RegisterDInjections(this IServiceCollection services)
        {
            //Methods
            services.AddTransient<DevPartnersEmployeeContext>();
            services.AddTransient<SendEmail>();
            services.AddTransient<EmailDaemon>();
            services.AddTransient<ResponseBadRequest>();
            services.AddTransient<CheckForgery>();
            services.AddTransient<GUIDMethod>();

            //classes
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IAuthenticate, Authenticate>();

            return services;
        }
    }
}
