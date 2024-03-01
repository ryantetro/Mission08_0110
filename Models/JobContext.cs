using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mission08_0110.Models
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed categories data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Home" },
                new Category { CategoryId = 2, Name = "Work" },
                new Category { CategoryId = 3, Name = "School" },
                new Category { CategoryId = 4, Name = "Church" }
            );
        }
    }
}
