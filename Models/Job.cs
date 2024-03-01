using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_0110.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job name is required")]
        public string JobName { get; set; }

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        public string Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        // New properties for the Category relationship
        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }  // Foreign key property

        public Category? Category { get; set; }  // Navigation property

        public bool? Completed { get; set; }
    }

}
