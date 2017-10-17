﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.Servises.Contracts
{
    public interface IUserServise
    {
        bool Create(string email, string name, string password);

        bool Find(string email, string password);

        bool IsAdmin(string email);
    }
}
