﻿using AutoMapper;
using CarService.BusinessLayer.Interfaces;
using CarService.BusinessLayer.Services;
using CarService.BusinessLayer.Validators;
using CarService.DataAccessLayer.Data;
using CarService.DataAccessLayer.Entities;
using CarService.DataAccessLayer.Interfaces;
using CarService.DataAccessLayer.Repositories;
using CarService.Shared.Models;
using CarService.WebMVC.Services;
using CarService.WebMVC.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

            // register the DbContext on the container, getting the connection string from
            // appSettings (note: use this during development; in a production environment,
            // it's better to store the connection string in an environment variable)
            var connectionString = Configuration["connectionStrings:CarServiceDBConnectionString"];
            services.AddDbContext<CarServiceDbContext>(o => o.UseSqlServer(connectionString));

            services.AddTransient<IRepository<CarType>, CarTypeRepository>();
            services.AddTransient<IRepository<UserDetail>, UserDetailRepository>();
            services.AddTransient<IRepository<OrderDetail>, OrderDetailRepository>();

            services.AddScoped<IService<CarTypeDto>, CarTypeService>();
            services.AddScoped<IService<UserDetailDto>, UserDetailService>();
            services.AddScoped<IService<OrderDetailDto>, OrderDetailService>();

            services.AddScoped<OrderDetailViewModelService>();

            services.AddTransient<AbstractValidator<CarTypeDto>, CarTypeDtoValidator>();
            services.AddTransient<AbstractValidator<UserDetailDto>, UserDetailDtoValidator>();
            services.AddTransient<AbstractValidator<OrderDetailDto>, OrderDetailDtoValidator>();

            var mapper = MapperConfiguration().CreateMapper();
            services.AddTransient(_ => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CarServiceDbContext carServiceDbContext)
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

            // Seed mock data
            carServiceDbContext.EnsureSeedDataForContext();

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

                cfg.CreateMap<OrderDetailViewModel, OrderDetailDto>()
                    .ForMember(o => o.SelectedCarType, 
                        opt => opt.MapFrom(ovm => 
                            new CarTypeDto()
                            {
                                ModelId = ovm.SelectedCarType,
                                Model = ovm.SelectedCarType.ToString()
                            }))
                    .ForMember(o => o.UserDetail, 
                        opt => opt.MapFrom(ovm => 
                            new UserDetailDto()
                            {
                                FirstName = ovm.FirstName,
                                SecondName = ovm.SecondName,
                                EMail = ovm.EMail,
                                PhoneNumber = ovm.PhoneNumber
                            }));
            });

            return config;
        }
    }
}
