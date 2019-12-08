using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class Course
    {
        [Key]
        public int CrsId { get; set; }
        [Required]
        [Display(Name = "Course Id")]
        public string CourseId { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Credit")]
        public string Credit { get; set; }
        [Required]
        [Display(Name = "Course Fee")]
        public float CourseFee { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
        public ICollection<Result> Result { get; set; }
        public ICollection<TeacherCourse> TeacherCourse { get; set; }
    }
}
