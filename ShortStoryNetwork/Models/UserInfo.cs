﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.Models
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserRole { get; set; }
        public bool IsEditor { get; set; }
        public bool IsBanned { get; set; }
    }
}
