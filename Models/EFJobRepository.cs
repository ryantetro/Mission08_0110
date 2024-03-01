
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mission08_0110.Models
{
    // Provides implementations for job-related operations using Entity Framework.
    public class EFJobRepository : IJobRepository
    {
        private JobContext _context;

        // Constructor to initialize the repository with a JobContext instance.
        public EFJobRepository(JobContext temp)
        {
            _context = temp;
        }

        // Retrieves all jobs from the database.

        public List<Job> Jobs => _context.Jobs.ToList();
        // Adds a new job to the database.

        public void AddJob(Job job)
        {
            _context.Add(job);
            _context.SaveChanges();
        }
        // Updates an existing job in the database.

        public void EditJob(Job job)
        {
            _context.Update(job);
            _context.SaveChanges();
        }

        // Deletes a job from the database
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
        // Adds a new category to the database.
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        // Retrieves a category by its ID from the database.
        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }
        // Updates an existing category in the database.
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        // Deletes a category by its ID from the database.
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
