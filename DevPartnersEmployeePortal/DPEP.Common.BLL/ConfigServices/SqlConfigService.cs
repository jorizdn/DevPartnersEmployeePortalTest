using DPEP.Common.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DPEP.Common.BLL.ConfigServices
{
    public static class SqlConfigService
    {
        public static IServiceCollection RegisterSqlServer(this IServiceCollection services, string dbConnection)
        {

            //Core Database Tables
            services.AddDbContext<DevPartnersEmployeeContext>(options => options.UseSqlServer(dbConnection));

            return services;
        }
    }
}
