using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Services.Contracts
{
    using Data.Models;

    public interface IUserService
    {
        bool Create(string email, string password, string fullName);

        bool UserExists(string email, string password);
    }
}
