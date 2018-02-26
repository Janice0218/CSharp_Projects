using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoLeague.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DojoLeague
{
    public class Startup
    {   
        //holds a copy of configuration object that is created by the build and holds json data I need for DB connection
        private IConfiguration _configuration;
        
        //ctor to inti the _configuration field and sets it to an instance of the object.
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //digs the connectionstring out of the configuration object and passes it to the SqlOptions class to set the defaultconnection prop I created.
            //now anything that needs the connetion string can get this class via dependency injection, and get the connectionstring (ex. the dbconnection class)
            services.Configure<MySqlOptions>(_configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<DataFactory>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //configures Mvc with defined routing pattern which uses urls with just the action name to return the view
            app.UseMvc(routes => routes.MapRoute("default", "{action=ninjas}/{id?}", new {controller="home"}));
        }
    }
}
