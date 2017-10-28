using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Services.Contracts
{
    using Data.Models;
    using Models.Admin;

    public interface IUserService
    {
        bool Create(string email, string password, PositionType position);

        bool UserExists(string email, string password);

        bool IsApproved(string email);

        IEnumerable<AdminUserModel> All();

        string Approve(int id);
    }
}
