namespace Mission08_0110.Models
{
    // Interface for job repository operations.
    public interface IJobRepository
    {
        // Property to retrieve all jobs.

        List<Job> Jobs { get; }

        // Methods for adding, editing, and deleting jobs.

        public void AddJob(Job job);

        public void EditJob(Job job);

        public void DeleteJob(Job job);

        // Add methods for category operations
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
        void SaveChanges();
    }
}
