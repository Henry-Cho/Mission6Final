using System;
using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class AppointmentResponse
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "GroupName is required")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "GroupSize is required")]
        public int GroupSize { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [MaxLength(ErrorMessage = "A phone number has nine digits")]
        public string Phone { get; set; }
    }
}
