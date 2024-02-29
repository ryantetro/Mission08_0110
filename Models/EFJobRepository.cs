
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mission08_0110.Models
{
    public class EFJobRepository : IJobRepository
    {
        private JobContext _context;
        public EFJobRepository(JobContext temp) 
        { 
            _context = temp;
        }

        public List<Job> Jobs => _context.Jobs.ToList();

        public void AddJob(Job job)
        {
            _context.Add(job);
            _context.SaveChanges();
        }

        public void EditJob(Job job)
        {
            _context.Update(job);
            _context.SaveChanges();
        }

        public void DeleteJob(Job job)
        {
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }
    }
}
