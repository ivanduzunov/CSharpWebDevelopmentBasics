﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolWebServer.ByTheCakeApplication.Models
{
    public class ShoppingCard
    {
        public const string SessionKey = "%^Current_Shopping_Card^%";


        public List<Cake> Orders { get; private set; } = new List<Cake>();
    }
}
