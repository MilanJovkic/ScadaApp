using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScadaCore
{
    [Serializable]
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}