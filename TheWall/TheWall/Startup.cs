using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWall.Models;
using TheWall.Properties;

namespace TheWall
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();

        //    Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
      
        public void ConfigureServices(IServiceCollection services)
        {


            services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
            services.AddScoped<DbConnector>();
            services.AddMvc();
//                .AddMvcOptions(options => options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "This field is required."));
            services.AddSession();
        }

  
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute("", "{controller=Home}/{action=login}"));

        }
    }
}

