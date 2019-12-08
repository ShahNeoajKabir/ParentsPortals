using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class Payment
    {

        [Key]
        public int PaymentId { get; set; }
        [Required]
        [Display(Name = "Student Id")]
        [ForeignKey("StudentCourse")]
        public int StudentCourseId { get; set; }
        public StudentCourse StudentCourse { get; set; }
        [Required]
        [Display(Name = "Semester Fee")]
        public float SemesterFee { get; set; }
    }
}
