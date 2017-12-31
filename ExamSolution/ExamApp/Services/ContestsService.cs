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
                     db.Contests
                     .Where(c => c.IsDeleted == false)
                     .Select(c =>
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
            if (name != null)
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

        public object Delete(int contestId)
        {
            using (var db = new ExamAppDbContext())
            {
                var contest = db.Contests
                    .Where(c => c.Id == contestId)
                    .FirstOrDefault();

                contest.IsDeleted = true;

                db.SaveChanges();

                return true;
            }
        }

        public string GetContestName(int id)
        {
            using (var db = new ExamAppDbContext())
            {             
                var contest = db.Contests.Where(c => c.Id == id).FirstOrDefault();

                return contest.Name;
            }

        }

        public bool HasPermitionToEditAndDeleteContest(int contestId, int userId)
        {
            using (var db = new ExamAppDbContext())
            {
                var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
                var contest = db.Contests.Where(c => c.Id == contestId).FirstOrDefault();

                if (user.IsAdmin || contest.CreatorId == userId)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
