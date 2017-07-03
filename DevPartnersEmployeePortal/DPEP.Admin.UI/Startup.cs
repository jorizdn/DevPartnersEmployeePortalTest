using DevPartners.Common.BLL.ConfigApp;
using DPEP.Common.BLL.ConfigServices;
using DPEP.Common.BLL.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DPEP.Admin.UI
{
    public class Startup
    {
        private static string _dbConnection;
        private static IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //    .AddEnvironmentVariables();

            var dalfolder = PathHelper.GetParentFolder(env);

            var builder =
                new ConfigurationBuilder().SetBasePath(dalfolder)
                    .AddJsonFile($"PublishSettings\\appSettings.{env.EnvironmentName}.json", optional: true);
            Configuration = builder.Build();
            _configurationRoot = builder.Build();
            _dbConnection = _configurationRoot.GetConnectionString("DefaultConnection");
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // var connection = "Data Source=devpartnersapi.cx49u7twr7h1.ap-northeast-2.rds.amazonaws.com;Integrated Security=False;User ID=sa;Password=1C1RLNS_enPH730PH730;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Database = DevPartnersEmployee;";
            // Add framework services.
            services.AddCors();
            services.RegisterSqlServer(_dbConnection);
            services.RegisterIdentities(_dbConnection);
            services.RegisterSwagger();
            services.RegisterDInjections();
            services.RegisterMapper();

            services.AddMvc();

            //services.Configure<AppSettingModel>(_configurationRoot.GetSection("SwaggerAuthentication"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder.WithOrigins("http://localhost").AllowAnyHeader()
               );

            //This will explicitly throw an text error with corresponding error code.
            app.UseStatusCodePages();

            //app.UseSwaggerAuthentication();

            //Contains UseMvc
            app.SetAppConfig();

            app.RegisterSwagger();
        }
    }
}
