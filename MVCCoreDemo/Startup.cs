using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCCoreDemo.Areas.Dashboard.Data;
using MVCCoreDemo.Areas.MasterSettings.Data;
using MVCCoreDemo.Areas.PaymentDetails.Data;
using MVCCoreDemo.Areas.UserAccess;
using MVCCoreDemo.Services;
using SimpleInjector;

namespace MVCCoreDemo
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();
        public IConfigurationRoot ConfigurationRoot { get; set; }
        public static string ConnectionString { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcCore();
            // services.AddControllersWithViews();
            services.AddSession();
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                .AddControllerActivation();
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Index"; // Set the login page URL
                options.LogoutPath = "/Account/Index"; // Set the logout page URL
               // options.AccessDeniedPath = "/Account/AccessDenied"; // Set the access denied page URL
            });
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });

            container.Register<ILoginService, LoginService>(Lifestyle.Singleton);
            container.Register<IUserAccessService, UserAccessService>(Lifestyle.Singleton);
            container.Register<IMasterSettingService, MasterSettingService>(Lifestyle.Singleton);
            container.Register<IDashboardService, DashboardService>(Lifestyle.Singleton);
            container.Register<IPaymentService, PaymentService>(Lifestyle.Singleton);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSimpleInjector(container);
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseSession();

            app.UseStaticFiles();
            ConnectionString = ConfigurationRoot.GetConnectionString("DefaultConnection");
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Account}/{action=Index}/{id?}");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");
            });
            app.UseAuthentication(); // Use authentication middleware
        }
        public Startup(IConfiguration config, IHostingEnvironment env)
        {

            ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json")
                .Build();
        }
    }
}
