using DPEP.Common.BLL.Interfaces;
using DPEP.Common.BLL.Repositories;
using DPEP.Common.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.ConfigServices
{
    public static class DInjectionConfigServices
    {
        public static IServiceCollection RegisterDInjections(this IServiceCollection services)
        {
            services.AddTransient<DevPartnersEmployeeContext>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
