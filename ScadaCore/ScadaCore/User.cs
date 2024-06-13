using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaCore
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}