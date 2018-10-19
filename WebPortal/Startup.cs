using Common.Mapping;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WebPortal.Infrastructure.Mappings;
using WebPortal.Tools.Mapster;
using WebPortalBuisenessLogic;
using WebPortalBuisenessLogic.Utils.Mapster;

namespace WebPortal
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped( mapper => {
                var maps = new TypeAdapterConfig();
                new ViewModelMaps(maps);
                new RegisterLocalMaps( maps );
                new RegisterCommonMaps( maps );
                return maps;  } 
            );

            services.AddScoped<ILogger>(provider => {
                return new LoggerConfiguration()
                    .WriteTo.Seq("http://logs.fitness-pro.ru:5341")
                    .CreateLogger();
            });

            services.AddScoped<BusinessLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();


            //if (env.IsDevelopment())
            //{
            //    app.UseBrowserLink();
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
