using System.ComponentModel.DataAnnotations;

namespace Mission08_0110.Models
{
    // Represents a category for organizing jobs
    public class Category
    {
        // Primary key for the category
        [Key]
        public int CategoryId { get; set; }

        // The name of the category, required field
        [Required]
        public string Name { get; set; }

        // Navigation property to relate each category to multiple jobs
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
