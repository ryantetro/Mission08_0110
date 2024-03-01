namespace Mission08_0110.Models
{
    public interface IJobRepository
    {
        List<Job> Jobs { get; }

        public void AddJob(Job job);

        public void EditJob(Job job);

        public void DeleteJob(Job job);

        // Add methods for category operations
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
