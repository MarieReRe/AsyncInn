using AsyncInn.Data;
using AsyncInn.Data.DatabaseRepositories;
using AsyncInn.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncInn
{
    public class Startup
    {

        //1. property to hold config info
        public IConfiguration Configuration { get; }

        //2. Add Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //3. Register DBContext
            services.AddDbContext<AsyncInnDbContext>( options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            //Dependency Injection:
            // AddTransient: Transient objects are always different; a new instance is provided to every controller and every service.
            services.AddTransient<IHotelRepository, DatabaseHotelRepository>();
            services.AddTransient<IRoomRepository,DatabaseRoomRepository>();
            services.AddTransient<IAmenitiesRepository, DatabaseAmenitiesRepository>();

            services.AddSingleton<>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
