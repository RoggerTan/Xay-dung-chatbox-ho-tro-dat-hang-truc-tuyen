﻿using System;
using System.Collections.Generic;

namespace CutieShop.API.Models.Entities.Models.Entities
{
    public partial class UserPoint
    {
        public string Username { get; set; }
        public int? Value { get; set; }

        public User UsernameNavigation { get; set; }
    }
}
