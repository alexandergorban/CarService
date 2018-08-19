using AutoMapper;
using CarService.BusinessLayer.Interfaces;
using CarService.BusinessLayer.Services;
using CarService.BusinessLayer.Validators;
using CarService.DataAccessLayer.Data;
using CarService.DataAccessLayer.Entities;
using CarService.DataAccessLayer.Interfaces;
using CarService.DataAccessLayer.Repositories;
using CarService.Shared.Models;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.WebMVC
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
            services.AddMvc();

            services.AddDbContext<CarServiceDbContext>();

            services.AddTransient<IRepository<CarType>, CarTypeRepository>();
            services.AddTransient<IRepository<UserDetail>, UserDetailRepository>();
            services.AddTransient<IRepository<OrderDetail>, OrderDetailRepository>();

            services.AddScoped<IService<CarTypeDto>, CarTypeService>();
            services.AddScoped<IService<UserDetailDto>, UserDetailService>();
            services.AddScoped<IService<OrderDetailDto>, OrderDetailService>();

            services.AddTransient<AbstractValidator<CarTypeDto>, CarTypeDtoValidator>();
            services.AddTransient<AbstractValidator<UserDetailDto>, UserDetailDtoValidator>();
            services.AddTransient<AbstractValidator<OrderDetailDto>, OrderDetailDtoValidator>();

            var mapper = MapperConfiguration().CreateMapper();
            services.AddTransient(_ => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarType, CarTypeDto>();
                cfg.CreateMap<CarTypeDto, CarType>();
                cfg.CreateMap<CarType, CarType>();

                cfg.CreateMap<UserDetail, UserDetailDto>();
                cfg.CreateMap<UserDetailDto, UserDetail>();
                cfg.CreateMap<UserDetail, UserDetail>();

                cfg.CreateMap<OrderDetail, OrderDetailDto>();
                cfg.CreateMap<OrderDetailDto, OrderDetail>();
                cfg.CreateMap<OrderDetail, OrderDetail>();
            });

            return config;
        }
    }
}
