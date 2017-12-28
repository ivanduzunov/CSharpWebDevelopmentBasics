using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Models.Contest
{
    public class ContestListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SubmitionsCount { get; set; }

        public bool CurrentUserIsCreator { get; set; }
    }
}
