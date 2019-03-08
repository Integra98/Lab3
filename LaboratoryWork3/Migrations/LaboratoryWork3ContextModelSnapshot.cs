﻿// <auto-generated />
using System;
using LaboratoryWork3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaboratoryWork3.Migrations
{
    [DbContext(typeof(LaboratoryWork3Context))]
    partial class LaboratoryWork3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaboratoryWork3.Models.Branch", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Branchid");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("Branchid");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("LaboratoryWork3.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Branchid");

                    b.Property<int?>("Employeeid");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("Branchid");

                    b.HasIndex("Employeeid");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("LaboratoryWork3.Models.EmployeeTask", b =>
                {
                    b.Property<int>("EmployeeID");

                    b.Property<int>("TaskID");

                    b.HasKey("EmployeeID", "TaskID");

                    b.HasIndex("TaskID");

                    b.ToTable("EmployeeTask");
                });

            modelBuilder.Entity("LaboratoryWork3.Models.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("LaboratoryWork3.Models.Branch", b =>
                {
                    b.HasOne("LaboratoryWork3.Models.Branch")
                        .WithMany("Branches")
                        .HasForeignKey("Branchid");
                });

            modelBuilder.Entity("LaboratoryWork3.Models.Employee", b =>
                {
                    b.HasOne("LaboratoryWork3.Models.Branch")
                        .WithMany("Employees")
                        .HasForeignKey("Branchid");

                    b.HasOne("LaboratoryWork3.Models.Employee")
                        .WithMany("Employees")
                        .HasForeignKey("Employeeid");
                });

            modelBuilder.Entity("LaboratoryWork3.Models.EmployeeTask", b =>
                {
                    b.HasOne("LaboratoryWork3.Models.Employee", "Employee")
                        .WithMany("EmployeeTask")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LaboratoryWork3.Models.Task", "Task")
                        .WithMany("EmployeeTask")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
