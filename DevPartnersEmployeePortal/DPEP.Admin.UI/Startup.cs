using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DPEP.Common.BLL.ConfigServices;
using DPEP.Common.DAL.Model;

namespace DPEP.Admin.UI
{
    public class Startup
    {
        private static IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = "Data Source=devpartnersapi.cx49u7twr7h1.ap-northeast-2.rds.amazonaws.com;Integrated Security=False;User ID=sa;Password=1C1RLNS_enPH730PH730;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Database = DevPartnersEmployee;";

            // Add framework services.
            services.RegisterSqlServer(connection);
            services.RegisterIdentities(connection);
            services.RegisterSwagger();
            services.RegisterDInjections();
            services.RegisterMapper();

            services.AddMvc();

            //#region appSettings

            //services.Configure<AppSettingModel>(_configurationRoot.GetSection("Document"));
            //services.Configure<AppSettingModel>(_configurationRoot.GetSection("SwaggerAuthentication"));
            //services.Configure<AppSettingModel>(_configurationRoot.GetSection("EmailNotification"));
            //services.Configure<AppSettingModel>(_configurationRoot.GetSection("Captcha"));
            //services.Configure<AppSettingModel>(_configurationRoot.GetSection("PipeDrive"));

            //#endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.RegisterSwagger();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
