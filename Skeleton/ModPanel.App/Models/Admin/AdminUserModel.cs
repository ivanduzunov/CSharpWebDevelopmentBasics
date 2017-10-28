﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Models.Admin
{
    using Data.Models;

    public class AdminUserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public PositionType Position { get; set; }

        public bool IsApproved { get; set; }
    }
}
