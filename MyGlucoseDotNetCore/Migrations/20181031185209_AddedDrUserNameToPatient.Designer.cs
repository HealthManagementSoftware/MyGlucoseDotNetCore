﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MyGlucoseDotNetCore.Data;
using System;

namespace MyGlucoseDotNetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181031185209_AddedDrUserNameToPatient")]
    partial class AddedDrUserNameToPatient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<long>("RemoteLoginExpiration");

                    b.Property<Guid>("RemoteLoginToken");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("Zip1");

                    b.Property<int>("Zip2");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.ExerciseEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ExerciseName");

                    b.Property<int>("Minutes");

                    b.Property<string>("PatientId");

                    b.Property<long>("Timestamp");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("UserId");

                    b.ToTable("ExerciseEntries");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.GlucoseEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeforeAfter");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<float>("Measurement");

                    b.Property<string>("PatientId");

                    b.Property<string>("PatientUsername");

                    b.Property<long>("Timestamp");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("WhichMeal");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("GlucoseEntries");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.MealEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("PatientId");

                    b.Property<long>("Timestamp");

                    b.Property<int>("TotalCarbs");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("UserId");

                    b.ToTable("MealEntries");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.MealItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Carbs");

                    b.Property<Guid>("MealId");

                    b.Property<string>("Name");

                    b.Property<int>("Servings");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("MealItems");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.Doctor", b =>
                {
                    b.HasBaseType("MyGlucoseDotNetCore.Models.ApplicationUser");

                    b.Property<string>("DegreeAbbreviation");

                    b.ToTable("Doctor");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.Patient", b =>
                {
                    b.HasBaseType("MyGlucoseDotNetCore.Models.ApplicationUser");

                    b.Property<string>("DoctorId");

                    b.Property<string>("DoctorUserName");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patient");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.ExerciseEntry", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.Patient")
                        .WithMany("ExerciseEntries")
                        .HasForeignKey("PatientId");

                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.GlucoseEntry", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.Patient", "Patient")
                        .WithMany("GlucoseEntries")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.MealEntry", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.Patient")
                        .WithMany("MealEntries")
                        .HasForeignKey("PatientId");

                    b.HasOne("MyGlucoseDotNetCore.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.MealItem", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.MealEntry", "Meal")
                        .WithMany("MealItems")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGlucoseDotNetCore.Models.Patient", b =>
                {
                    b.HasOne("MyGlucoseDotNetCore.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId");
                });
#pragma warning restore 612, 618
        }
    }
}
