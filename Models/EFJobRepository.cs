
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

        // Synchronous category methods implementation
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
