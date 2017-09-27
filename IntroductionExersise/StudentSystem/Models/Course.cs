using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    //•	Courses: id, name, description(optional), start date, end date, pric
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Price { get; set; }

        public List<StudentCourse> Students { get; set; }

        public List<Resource> Resources { get; set; }

        public List<Homework> Homeworks { get; set; }
    }
}
