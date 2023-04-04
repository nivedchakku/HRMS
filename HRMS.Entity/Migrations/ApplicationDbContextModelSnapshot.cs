﻿// <auto-generated />
using System;
using HRMS.Entity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRMS.Entity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HRMS.Entity.Models.Attandance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("employeeid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timein")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timeout")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("attandance");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Department", b =>
                {
                    b.Property<int>("deptid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deptid"), 1L, 1);

                    b.Property<string>("deptname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.HasKey("deptid");

                    b.ToTable("department");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Employee", b =>
                {
                    b.Property<string>("employeeid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("departmentid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("mobile")
                        .HasColumnType("bigint");

                    b.Property<int>("positionid")
                        .HasColumnType("int");

                    b.Property<int>("salaryid")
                        .HasColumnType("int");

                    b.HasKey("employeeid");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Leave", b =>
                {
                    b.Property<int>("leaveid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("leaveid"), 1L, 1);

                    b.Property<int>("days")
                        .HasColumnType("int");

                    b.Property<string>("leavename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("leaveid");

                    b.ToTable("leave");
                });

            modelBuilder.Entity("HRMS.Entity.Models.LeaveApp", b =>
                {
                    b.Property<int>("leaveapplyid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("leaveapplyid"), 1L, 1);

                    b.Property<DateTime>("dateapplied")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("enddate")
                        .HasColumnType("datetime2");

                    b.Property<int>("leavedays")
                        .HasColumnType("int");

                    b.Property<int>("leaveid")
                        .HasColumnType("int");

                    b.Property<DateTime>("startdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("leaveapplyid");

                    b.ToTable("leave_application");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Position", b =>
                {
                    b.Property<int>("positionid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("positionid"), 1L, 1);

                    b.Property<bool>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("positionname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("positionid");

                    b.ToTable("position");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Project", b =>
                {
                    b.Property<int>("projectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("projectid"), 1L, 1);

                    b.Property<DateTime?>("enddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("projectname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("projectid");

                    b.ToTable("project");
                });

            modelBuilder.Entity("HRMS.Entity.Models.ProjectAllocation", b =>
                {
                    b.Property<int>("allocationid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("allocationid"), 1L, 1);

                    b.Property<DateTime>("allocationdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("employeeid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("projectid")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("allocationid");

                    b.ToTable("project_allocation");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Salary", b =>
                {
                    b.Property<int>("salaryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("salaryid"), 1L, 1);

                    b.Property<int>("pf")
                        .HasColumnType("int");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.Property<int>("specialallowance")
                        .HasColumnType("int");

                    b.HasKey("salaryid");

                    b.ToTable("salary");
                });

            modelBuilder.Entity("HRMS.Entity.Models.Training", b =>
                {
                    b.Property<int>("trainingid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trainingid"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trainingname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trainingid");

                    b.ToTable("training");
                });

            modelBuilder.Entity("HRMS.Entity.Models.TrainingAllocation", b =>
                {
                    b.Property<int>("trainingallocationid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trainingallocationid"), 1L, 1);

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("employeeid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("trainingid")
                        .HasColumnType("int");

                    b.HasKey("trainingallocationid");

                    b.ToTable("training_allocation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
