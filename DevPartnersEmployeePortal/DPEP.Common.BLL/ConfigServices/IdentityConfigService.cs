﻿using DPEP.Common.DAL.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DPEP.Common.BLL.ConfigServices
{
    public static class IdentityConfigService
    {
        public static IServiceCollection RegisterIdentities(this IServiceCollection services, string dbConnection)
        {

            //Identity Database Tables
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnection));

            ////Identity Configuration
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(opt =>
            {


            })
                .AddEntityFrameworkStores<ApplicationDbContext, int>()
                .AddDefaultTokenProviders();

            services.AddScoped<RoleManager<IdentityRole<int>>>();

            services.AddScoped<UserManager<ApplicationUser>>();

            return services;
        }

        private static IdentityOptions IdentityOptions(this IdentityOptions option)
        {

            option.Password.RequireDigit = false;
            option.Password.RequireLowercase = false;
            option.Password.RequireUppercase = false;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequiredLength = 6;
            return option;
        }
    }
}
