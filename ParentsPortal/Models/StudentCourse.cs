using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }
        [Required]
        [Display(Name = "Student Id")]
        [ForeignKey("StudentInfo")]
        public int StdId { get; set; }
        public StudentInfo StudentInfo { get; set; }
        [Required]
        [Display(Name = "Course Id")]
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public Course Course { get; set; }
        [Required]
        [Display(Name = "Semester")]
        public string Semester { get; set; }
    }
}
