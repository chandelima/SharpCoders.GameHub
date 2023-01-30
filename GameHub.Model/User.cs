using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Model
{
    public class User
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
