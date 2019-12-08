using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class Teacher
    {
        [Key]
        public int TcrId { get; set; }
        [Required]
        [Display(Name = "Teacher Id")]
        public string TeacherId { get; set; }
        [Required]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "User Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<TeacherCourse> TeacherCourse { get; set; }
    }
}
