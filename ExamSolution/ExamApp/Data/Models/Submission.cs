using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Data.Models
{
    public class Submission
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public Contest Contest { get; set; }

        public int ContestId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
