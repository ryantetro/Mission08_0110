using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Mission08_0110.Models
{
    public class Job
    {
        [Key]
        [Required(ErrorMessage = "JobId is requried")]
        public int JobId { get; set; }
        [Required]
        public string JobName { get; set; }
        public DateTime? DueDate { get; set; }
        [Required]
        public string Quadrant { get; set; }
        public string? CategoryName { get; set; }
        public bool? Completed { get; set; }

    }
}
