using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//define the models for a job tracking system
namespace Mission08_0110.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        //[Required(ErrorMessage = "Job name is required")]
        public required string JobName { get; set; }

        public DateTime? DueDate { get; set; }

        //[Required(ErrorMessage = "Quadrant is required")]
        public required string Quadrant { get; set; }

        [ForeignKey("Category")]
        // New properties for the Category relationship
        public int? CategoryId { get; set; }  // Foreign key property

        public Category? Category { get; set; }  // Navigation property

        public bool Completed { get; set; } = false; 
    }

}
