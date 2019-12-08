using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class Notice
    {

        [Key]
        public int NoticeId { get; set; }
        [Required]
        [Display(Name = "Notice")]
        public string Notices { get; set; }
    }
}
