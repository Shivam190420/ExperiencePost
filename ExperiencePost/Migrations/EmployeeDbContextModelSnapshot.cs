﻿// <auto-generated />
using ExperiencePost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExperiencePost.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeesEmpID")
                        .HasColumnType("int");

                    b.Property<int>("SkillsSkillId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmpID", "SkillsSkillId");

                    b.HasIndex("SkillsSkillId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("ExperiencePost.Models.Employee", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpID"), 1L, 1);

                    b.Property<string>("CellNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ExperiencePost.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<int>("EmpID")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceInYears")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EmployeeSkill", b =>
                {
                    b.HasOne("ExperiencePost.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExperiencePost.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}