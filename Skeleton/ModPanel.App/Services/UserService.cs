using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System.Linq;
    using Models;
    using ModPanel.App.Models.Admin;

    public class UserService : IUserService
    {
        private readonly ModPanelDbContext db;

        public UserService()
        {
            this.db = new ModPanelDbContext();
        }

      
        public bool Create(string email, string password, PositionType position)
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
                IsAdmin = isAdmin,
                IsApproved = isAdmin,
                Position = position,
            };

            db  .Add(user);
            db.SaveChanges();
            return true;
        }

        public bool IsApproved(string email)
           => this.db
               .Users
               .Any(u => u.Email == email && u.IsApproved);

        public bool UserExists(string email, string password)
        {
            return this.db.Users.Any(u => u.Email == email);
        }

        public IEnumerable<AdminUserModel> All()
        {
           return this.db
                .Users
                .Select(u => new AdminUserModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Position = u.Position,
                    IsApproved = u.IsApproved
                })
                .ToList();
        }

        public string Approve(int id)
        {
            var user = this.db.Users.Find(id);

            if (user != null)
            {
                user.IsApproved = true;

                this.db.SaveChanges();
            }

            return user?.Email;
        }
    }
}
