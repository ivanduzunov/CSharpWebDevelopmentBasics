using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.Models;
using MyCoolWebServer.GameStoreApplication.Servises.Contracts;

namespace MyCoolWebServer.GameStoreApplication.Servises
{
    public class UserServise : IUserServise
    {
        public bool Create(string email, string name, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !db.Users.Any();

                var user = new User
                {
                    Email = email,
                    FullName = name,
                    Password = password,
                    IsAdmin = isAdmin

                };

                db.Add(user);
                db.SaveChanges();
            }
            return true;
        }

        public bool Find(string email, string password)
        {
            using (var context = new GameStoreDbContext())
            {
                return context.Users.Any(u => u.Email == email && u.Password == password);
            }
        }

        public bool IsAdmin(string email)
        {
            using (var context = new GameStoreDbContext())
            {
                return context.Users.Any(u => u.Email == email && u.IsAdmin == true);
            }
        }
    }
}
