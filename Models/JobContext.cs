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
    }
}
