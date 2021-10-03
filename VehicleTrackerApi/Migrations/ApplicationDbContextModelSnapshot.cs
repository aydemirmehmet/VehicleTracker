﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using VehicleApi.Contexts;

namespace VehicleTrackerApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Geometry>("Location")
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Location = (NetTopologySuite.Geometries.Polygon)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POLYGON ((35.6 36.6, 35.7 36.6, 35.7 36.6, 35.6 36.6))"),
                            Name = "test"
                        });
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateReportDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("ReportState")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Point>("CurrentLocation")
                        .HasColumnType("geography");

                    b.Property<string>("RegisterNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentLocation = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (35.6 36.6)"),
                            RegisterNumber = "04TT336"
                        },
                        new
                        {
                            Id = 2,
                            CurrentLocation = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (35.6 36.6)"),
                            RegisterNumber = "34ET336"
                        },
                        new
                        {
                            Id = 3,
                            CurrentLocation = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (35.6 36.6)"),
                            RegisterNumber = "04BT336"
                        },
                        new
                        {
                            Id = 4,
                            CurrentLocation = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (35.6 36.6)"),
                            RegisterNumber = "04TA336"
                        },
                        new
                        {
                            Id = 5,
                            CurrentLocation = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (35.6 36.6)"),
                            RegisterNumber = "04AT336"
                        },
                        new
                        {
                            Id = 6,
                            CurrentLocation = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (35.6 36.6)"),
                            RegisterNumber = "12AZ1236"
                        });
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.VehiclePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehiclePositions");
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.Report", b =>
                {
                    b.HasOne("VehicleTrackerApi.Data.Model.Place", "Place")
                        .WithMany("Reports")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehicleTrackerApi.Data.Model.Vehicle", "Vehicle")
                        .WithMany("Reports")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.VehiclePosition", b =>
                {
                    b.HasOne("VehicleTrackerApi.Data.Model.Vehicle", "Vehicle")
                        .WithMany("VehiclePositions")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.Place", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("VehicleTrackerApi.Data.Model.Vehicle", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("VehiclePositions");
                });
#pragma warning restore 612, 618
        }
    }
}
