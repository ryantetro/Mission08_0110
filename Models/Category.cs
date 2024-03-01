using System.ComponentModel.DataAnnotations;

namespace Mission08_0110.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property to relate each category to multiple jobs
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
