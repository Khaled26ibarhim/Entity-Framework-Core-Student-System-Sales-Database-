using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.P01__StudentSystem.Models__;

namespace P01_StudentSystem.P01__StudentSystem.Data__
{
    public class StudentSystemContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-U91DJFF\\SQLEXPRESS;initial catalog=StudentSystemContext;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });


            modelBuilder.Entity<Student>().HasData(
                 new Student { StudentId = 1, Name = "Ahmed Ali", PhoneNumber = "0123456789", RegisteredOn = new DateTime(2025, 9, 27) },
                 new Student { StudentId = 2, Name = "Sara Mohamed", RegisteredOn = new DateTime(2025, 8, 28) }
             );

            // بيانات تجريبية للـ Courses
            modelBuilder.Entity<Course>().HasData(
                 new Course { CourseId = 1, Name = "C# Basics", StartDate = new DateTime(2025, 9, 1), EndDate = new DateTime(2025, 10, 1), Price = 200 },
                 new Course { CourseId = 2, Name = "Databases", StartDate = new DateTime(2025, 9, 1), EndDate = new DateTime(2025, 11, 1), Price = 300 }
             );

            modelBuilder.Entity<Resource>().HasData(
                   new Resource { ResourceId = 1, Name = "C# Book", Url = "http://example.com/book", ResourceType = ResourceType.Document, CourseId = 1 },
                   new Resource { ResourceId = 2, Name = "SQL Slides", Url = "http://example.com/slides", ResourceType = ResourceType.Presentation, CourseId = 2 }
               );

            modelBuilder.Entity<Homework>().HasData(
                  new Homework { HomeworkId = 1, Content = "http://example.com/hw1", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2025, 9, 10), StudentId = 1, CourseId = 1 },
                  new Homework { HomeworkId = 2, Content = "http://example.com/hw2", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2025, 9, 15), StudentId = 2, CourseId = 2 }
              );
            // بيانات تجريبية للـ StudentCourse (الربط بين الطلاب والكورسات)
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { StudentId = 1, CourseId = 1 },
                new StudentCourse { StudentId = 2, CourseId = 2 }
            );
        }

    }
}
