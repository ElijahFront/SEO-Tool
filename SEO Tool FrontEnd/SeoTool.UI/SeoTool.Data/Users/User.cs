﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SeoTool.Data
{
    public class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User (string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
