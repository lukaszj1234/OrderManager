using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManager.DataAccess;
using Microsoft.Extensions.Configuration;
using OrderManager.DataAccess.Repositories;
using OrderManager.DataAccess.Repositories.Interfaces;
using AutoMapper;
using OrderManager.Configuration;
using Microsoft.AspNetCore.Identity;
using OrderManager.DataAccess.Models;

namespace OrderManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
           Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddDbContext<OrderManagerDbContext>(options =>
               options.UseSqlServer(
                   Configuration["Data:OrderManagerDb:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<OrderManagerDbContext>()
            .AddDefaultTokenProviders();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: null,
                     template: "{controller?}/{action?}",
                     defaults: new { Controller = "AdminOrders", action = "NewOrders" });
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
        });
        }
    }
}
