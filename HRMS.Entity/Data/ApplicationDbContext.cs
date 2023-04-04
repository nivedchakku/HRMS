using HRMS.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LeaveApp> LeaveApp { get; set; }
        public DbSet<TrainingAllocation> TrainingAllocation { get; set; }
        public DbSet<ProjectAllocation> ProjectAllocation { get; set; }
        public DbSet<Attandance> Attandance { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<LeaveApplication>()
        //        .HasKey(l => new { l.leaveid, l.employeeid });
        //}

    }
}
