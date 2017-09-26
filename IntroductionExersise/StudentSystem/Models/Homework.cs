﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Models
{
    //•	Homework: id, content, content-type (application/pdf/zip), submission date
    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }
    }
}
