using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaboratoryWork3.Models;

namespace LaboratoryWork3.Models
{
    public class LaboratoryWork3Context : DbContext
    {
        public LaboratoryWork3Context (DbContextOptions<LaboratoryWork3Context> options)
            : base(options)
        {
        }

        public DbSet<LaboratoryWork3.Models.Branch> Branch { get; set; }

        public DbSet<LaboratoryWork3.Models.Employee> Employee { get; set; }

        public DbSet<LaboratoryWork3.Models.Task> Task { get; set; }

        public DbSet<LaboratoryWork3.Models.EmployeeTask> EmployeeTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>()
                .HasKey(bc => new { bc.EmployeeID, bc.TaskID });
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeTask)
                .HasForeignKey(bc => bc.EmployeeID);
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(bc => bc.Task)
                .WithMany(c => c.EmployeeTask)
                .HasForeignKey(bc => bc.TaskID);
        }

    }
}
