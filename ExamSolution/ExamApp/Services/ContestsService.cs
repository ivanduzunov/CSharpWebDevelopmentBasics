using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Services
{
    using ExamApp.Models.Contest;
    using Services.Contracts;
    using Data;
    using System.Linq;
    using Data.Models;

    public class ContestsService : IContestsService
    {
        public IEnumerable<ContestListingModel> All(int id)
        {
            using (var db = new ExamAppDbContext())
            {
                var allContests =
                     db.Contests.Select(c =>
                     new ContestListingModel
                     {
                         Id = c.Id,
                         Name = c.Name,
                         SubmitionsCount = c.Submitions.Count,
                         CurrentUserIsCreator = c.CreatorId == id
                     })
                     .ToList();

                return allContests;
            }        
        }

        public bool Create(string name, int userId)
        {
            if (name!=null)
            {
                using (var db = new ExamAppDbContext())
                {
                    var contest = new Contest
                    {
                        Name = name,
                        CreatorId = userId
                    };

                    db.Contests.Add(contest);

                    db.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
