using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Data.Models
{
   public  class Contest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Submission> Submitions { get; set; }

        public User Creator { get; set; }   

        public int CreatorId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
