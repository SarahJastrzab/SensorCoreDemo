﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SensorData.DBContext;
using System;

namespace SensorData.Migrations
{
    [DbContext(typeof(SensorContext))]
    [Migration("20180220193515_InitialCreate5")]
    partial class InitialCreate5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SensorData.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuildingCode");

                    b.Property<string>("FloorCode");

                    b.Property<string>("RoomCode");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SensorData.Models.Sensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ExpectedMax");

                    b.Property<double>("ExpectedMin");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("SensorCode");

                    b.Property<int>("SensorTypeId");

                    b.HasKey("ID");

                    b.HasIndex("LocationId");

                    b.HasIndex("SensorTypeId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("SensorData.Models.SensorType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("ReadUnits");

                    b.HasKey("ID");

                    b.ToTable("SensorTypes");
                });

            modelBuilder.Entity("SensorData.Models.Sensor", b =>
                {
                    b.HasOne("SensorData.Models.Location", "Location")
                        .WithMany("Sensors")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SensorData.Models.SensorType", "SensorType")
                        .WithMany("Sensors")
                        .HasForeignKey("SensorTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
