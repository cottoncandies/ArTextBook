using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alva.ArTextBook.Utils;
using Alva.ArTextBook.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scietec.Combine.AspNetCore;
using Microsoft.AspNetCore.StaticFiles;

namespace Alva.ArTextBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            FeaturesLayoutModel featuresLayoutModel = new FeaturesLayoutModel();
            services.AddMvc(o => o.Conventions.Add(featuresLayoutModel))
               .AddRazorOptions(
               options =>
               {
                   featuresLayoutModel.SetFeaturesViewLocations(options);
               }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(options =>
               {
                   options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
               }); ;

            services.AddDistributedMemoryCache();
            /*services.AddSession(options =>
            {
                options.Cookie.Name = ".XSPSession";
                options.IdleTimeout = TimeSpan.FromMinutes(30);//设置session的过期时间
                options.Cookie.HttpOnly = true;//设置在浏览器不能通过js获得该cookie的值
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = WebApp.GetContentTypeProvider()
            });

            // app.UseCookiePolicy();
            //app.UseSession();
            app.UseMiddleware<AuthCheckMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}
