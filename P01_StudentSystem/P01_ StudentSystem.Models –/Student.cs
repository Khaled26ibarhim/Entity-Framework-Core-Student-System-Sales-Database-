using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.P01__StudentSystem.Models__
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(100)]
        [Unicode(true)] 
        public string ?Name { get; set; } 

        [MaxLength(10)]
        [Unicode(false)] 
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }
        //Navigation Properties
        public List<StudentCourse> CourseEnrollments { get; set; }
        public List<Homework> HomeworkSubmissions { get; set; }

    }
}
