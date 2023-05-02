using EntityFrameworkCoreINHA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreINHA.Context
{
    public class INHAContext : DbContext
    {
        public INHAContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-39JSBQ6;Database=INHA;User Id=inha;Password=12345678;Encrypt=false;");
            optionsBuilder.LogTo(m => Debug.WriteLine(m), new[] { RelationalEventId.CommandExecuted });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Student>()
                .HasMany<Grade>(s => s.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(s => s.CurrentCourseId)
                .OnDelete(DeleteBehavior.Cascade);
            */
        }

        //entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
