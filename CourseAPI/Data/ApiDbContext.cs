using CourseAPI.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Data
{
    public class ApiDbContext:DbContext
    {
        public DbSet<CourseEntity> Courses { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseEntity>().ToTable("Courses");
            modelBuilder.Entity<CourseEntity>().Property(b => b.Id).ValueGeneratedOnAdd();
        }

    }
}
