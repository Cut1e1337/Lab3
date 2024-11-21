﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab3.Repositories.Data;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.AppGenre", b =>
                {
                    b.Property<int>("AppGenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppGenreID"));

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.HasKey("AppGenreID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("GenreID");

                    b.ToTable("AppGenres");
                });

            modelBuilder.Entity("Core.Models.AppType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeID"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TypeID");

                    b.ToTable("AppTypes");
                });

            modelBuilder.Entity("Core.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ContentRatingID")
                        .HasColumnType("int");

                    b.Property<string>("CurrentVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MinAndroidVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ApplicationID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ContentRatingID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Models.ContentRating", b =>
                {
                    b.Property<int>("ContentRatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentRatingID"));

                    b.Property<string>("RatingName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ContentRatingID");

                    b.ToTable("ContentRatings");
                });

            modelBuilder.Entity("Core.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreID"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Core.Models.Installation", b =>
                {
                    b.Property<int>("InstallationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstallationID"));

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<string>("Installs")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstallationID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("Installations");
                });

            modelBuilder.Entity("Core.Models.Pricing", b =>
                {
                    b.Property<int>("PricingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricingID"));

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("PricingID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("TypeID");

                    b.ToTable("Pricings");
                });

            modelBuilder.Entity("Core.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.Property<int>("ReviewCount")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.UserRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Core.Models.AppGenre", b =>
                {
                    b.HasOne("Core.Models.Application", "Application")
                        .WithMany("AppGenres")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Genre", "Genre")
                        .WithMany("AppGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Core.Models.Application", b =>
                {
                    b.HasOne("Core.Models.Category", "Category")
                        .WithMany("Applications")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ContentRating", "ContentRating")
                        .WithMany("Applications")
                        .HasForeignKey("ContentRatingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ContentRating");
                });

            modelBuilder.Entity("Core.Models.Installation", b =>
                {
                    b.HasOne("Core.Models.Application", "Application")
                        .WithMany("Installations")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Core.Models.Pricing", b =>
                {
                    b.HasOne("Core.Models.Application", "Application")
                        .WithMany("Pricings")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.AppType", "AppType")
                        .WithMany("Pricings")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppType");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Core.Models.Review", b =>
                {
                    b.HasOne("Core.Models.Application", "Application")
                        .WithMany("Reviews")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.HasOne("Core.Models.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Models.AppType", b =>
                {
                    b.Navigation("Pricings");
                });

            modelBuilder.Entity("Core.Models.Application", b =>
                {
                    b.Navigation("AppGenres");

                    b.Navigation("Installations");

                    b.Navigation("Pricings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("Core.Models.ContentRating", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("Core.Models.Genre", b =>
                {
                    b.Navigation("AppGenres");
                });

            modelBuilder.Entity("Core.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}