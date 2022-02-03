using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "TaskName is required")]
        public string TaskName { get; set; }
    
        public string DueDate { get; set; }

        [Range(1,4)]
        public int Quadrant { get; set; }

        public int Categoryid { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }
    }
}
