using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsPortal.Models
{
    public class ParentsDbContext : DbContext
    {
        public ParentsDbContext(DbContextOptions<ParentsDbContext> options) : base(options)
        {

        }
        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherCourse> TeacherCourse { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Payment> Payment { get; set; }








    }
}
