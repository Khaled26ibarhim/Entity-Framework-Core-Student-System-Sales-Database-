using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.P01__StudentSystem.Models__
{
    public  class Course
    {
        [Key]
        public int CourseId { get; set; }

        [MaxLength(80)]
        [Unicode(true)]
        public string? Name { get; set; } 

        [Unicode(true)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public List<Student> StudentsEnrolled { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Homework> HomeworkSubmissions { get; set; }


    }
}
