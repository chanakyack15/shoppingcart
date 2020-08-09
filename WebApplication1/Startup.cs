using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Data;

namespace WebApplication1
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) 
        {
            _config = config;

        }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<shoppingContext>(cfg => {
                cfg.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<WebApplicationSeeder>();

            services.AddScoped<IRepo, Repo>();
            services.AddControllersWithViews();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseNodeModules();
            app.UseRouting();
            app.UseEndpoints(cfg => {
                cfg.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                new {controller="App",action = "Index" });
            }); 
        }
    }
}
