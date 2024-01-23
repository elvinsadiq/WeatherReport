﻿// <auto-generated />
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Domain.Entities.WeatherReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Clouds")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<float>("FeelsLike")
                        .HasColumnType("float");

                    b.Property<float>("GroundLevel")
                        .HasColumnType("float");

                    b.Property<float>("Humidity")
                        .HasColumnType("float");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Main")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float>("Pressure")
                        .HasColumnType("float");

                    b.Property<float>("SeaLevel")
                        .HasColumnType("float");

                    b.Property<float>("Temp")
                        .HasColumnType("float");

                    b.Property<float>("TempMax")
                        .HasColumnType("float");

                    b.Property<float>("TempMin")
                        .HasColumnType("float");

                    b.Property<int>("WeatherId")
                        .HasColumnType("int");

                    b.Property<float>("WindDegree")
                        .HasColumnType("float");

                    b.Property<float>("WindGust")
                        .HasColumnType("float");

                    b.Property<float>("WindSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("WeatherReports");
                });

            modelBuilder.Entity("Domain.Entities.WeatherReport", b =>
                {
                    b.HasOne("Domain.Entities.District", "District")
                        .WithMany("WeatherReports")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("Domain.Entities.District", b =>
                {
                    b.Navigation("WeatherReports");
                });
#pragma warning restore 612, 618
        }
    }
}
