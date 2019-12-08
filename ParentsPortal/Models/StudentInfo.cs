using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class StudentInfo
    {
        [Key]
        public int StdId { get; set; }
        [Required]
        [Display(Name = "Student Id")]
        public string StudentId { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Required]
        [Display(Name = "Fathe")]
        public string Fathe { get; set; }
        [Required]
        [Display(Name = "Mother")]
        public string Mother { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [Phone]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "User Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Batch")]
        public string Batch { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}
