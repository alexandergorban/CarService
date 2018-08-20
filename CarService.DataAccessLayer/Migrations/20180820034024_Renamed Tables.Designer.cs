﻿// <auto-generated />
using System;
using CarService.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarService.DataAccessLayer.Migrations
{
    [DbContext(typeof(CarServiceDbContext))]
    [Migration("20180820034024_Renamed Tables")]
    partial class RenamedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarService.DataAccessLayer.Entities.CarType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("ModelId");

                    b.HasKey("Id");

                    b.ToTable("ag_CarTypes");
                });

            modelBuilder.Entity("CarService.DataAccessLayer.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFirst");

                    b.Property<DateTime>("DataSecond");

                    b.Property<string>("OrderMessage");

                    b.Property<bool>("Other");

                    b.Property<Guid?>("SelectedCarTypeId");

                    b.Property<DateTime>("TimeFirst");

                    b.Property<DateTime>("TimeSecond");

                    b.Property<bool>("Transmission");

                    b.Property<Guid>("UserDetailId");

                    b.Property<bool>("VehicleMaintenance");

                    b.Property<bool>("VehicleRapair");

                    b.Property<string>("YearOfCar");

                    b.HasKey("Id");

                    b.HasIndex("SelectedCarTypeId");

                    b.HasIndex("UserDetailId");

                    b.ToTable("ag_OrdersDetail");
                });

            modelBuilder.Entity("CarService.DataAccessLayer.Entities.UserDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.ToTable("ag_UsersDetail");
                });

            modelBuilder.Entity("CarService.DataAccessLayer.Entities.OrderDetail", b =>
                {
                    b.HasOne("CarService.DataAccessLayer.Entities.CarType", "SelectedCarType")
                        .WithMany()
                        .HasForeignKey("SelectedCarTypeId");

                    b.HasOne("CarService.DataAccessLayer.Entities.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
