﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Authentication
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
