﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
