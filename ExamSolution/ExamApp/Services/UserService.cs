using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System.Linq;
    using Models;

    public class UserService : IUserService
    {
        private readonly ExamAppDbContext db;

        public UserService()
        {
            this.db = new ExamAppDbContext();
        }


        public bool Create(string email, string password, string fullName)
        {
            if (this.db.Users.Any(u => u.Email == email))
            {
                return false;
            }

            var isAdmin = !this.db.Users.Any();

            var user = new User
            {
                Email = email,
                Password = password,
                FullName = fullName,
                IsAdmin = isAdmin           
            };

            db.Users.Add(user);
            db.SaveChanges();

            return true;
        }   

        public bool UserExists(string email, string password)
        {
            return this.db.Users.Any(u => u.Email == email);
        }


       
    }
}
