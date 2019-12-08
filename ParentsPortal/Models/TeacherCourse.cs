using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class TeacherCourse
    {
        [Key]
        public int TeacherCourseId { get; set; }
        [Required]
        [Display(Name = "Teacher Id")]
        [ForeignKey("Teacher")]
        public int TcrId { get; set; }
        public Teacher Teacher { get; set; }
        [Required]
        [Display(Name = "Course Id")]
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public Course Course { get; set; }
    }
}
