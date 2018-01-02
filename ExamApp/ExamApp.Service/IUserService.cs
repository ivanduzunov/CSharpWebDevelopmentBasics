﻿namespace ExamApp.Services
{
    public interface IUserService
    {
        bool Create(string email, string password, string fullName);

        bool UserExists(string email, string password);
    }
}
