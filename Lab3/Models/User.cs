﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public UserRole Role { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<UserPurchase> UserPurchases { get; set; }
    }
}
