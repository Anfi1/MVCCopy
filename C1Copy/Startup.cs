using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using C1Copy.Controllers;
using C1Copy.Models;

namespace TestPages3
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private Dictionary<string,string> config2;
        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/Account/Login");
            services.AddAuthorization();
            services.AddScoped<ApplicationContext>();

            services.AddControllersWithViews();
            
            //Сервис времени существования
            services.AddTransient<UpTimeServiceSeconds>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UpTimeServiceSeconds time)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Database}/{action=Index}/{id?}");
            });
        }
    }
}
