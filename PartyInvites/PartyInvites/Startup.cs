using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PartyInvites
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
        {   //****ALWAYS ADD TO MVC****
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {   //shows error handling in browser while in development
                app.UseDeveloperExceptionPage();
                //adds capability for displaying multiple browsers
                app.UseBrowserLink();
            }
            else
            {
                //uses exception handle while not in development
                app.UseExceptionHandler("/Home/Error");
            }
            //loads static files
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default", //route's name
                    template: "{controller=Home}/{action=Index}/{id?}"); //pattern that route matches
            });
        }
    }
}
