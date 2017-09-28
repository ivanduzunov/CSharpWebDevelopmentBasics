using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using StudentSystem.Models;

namespace StudentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();
            //db.Database.EnsureDeleted(); 
            //db.Database.EnsureCreated();

            StudentsAndHomeworks(db);
            CoursesAndResourses(db);
            CoursesWithMoreThanFiveResourses(db);




        }

        private static void CoursesWithMoreThanFiveResourses(StudentSystemContext db)
        {
            var result = db.Courses
                .Select(c => new {c.Name, c.StartDate, ResourseCount = c.Resources.Count})
                .OrderByDescending(c => c.ResourseCount)
                .ThenByDescending(c => c.StartDate);

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} --- {course.ResourseCount}");
            }
        }

        private static void CoursesAndResourses(StudentSystemContext db)
        {
            var courses = db.Courses.Select(c => new {c.Name, c.Description, c.Resources,});

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
                Console.WriteLine(course.Description);

                foreach (var resourse in course.Resources)
                {
                    Console.WriteLine($"{resourse.Name} {resourse.ResourceType} {resourse.URL}");
                }


            }
        }

        private static void StudentsAndHomeworks(StudentSystemContext db)
        {
            var result = db.Students.Select(h => new
            {
                h.Name,
                Homework = h.Homeworks.Select(s => new { s.Content, s.ContentType })
            });

            foreach (var student in result)
            {
                Console.WriteLine(student.Name);
                foreach (var homework in student.Homework)
                {
                    Console.WriteLine($"Homework name: {homework.Content}, Type: {homework.ContentType}");
                }
            }
        }
    }
}
