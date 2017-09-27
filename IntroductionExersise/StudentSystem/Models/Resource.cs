using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using StudentSystem.Validations;

namespace StudentSystem.Models
{
    //•	Resources: id, name, type of resource (video / presentation / document / other), URL
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ResourceType { get; set; }

        [Required]
        public string URL { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
