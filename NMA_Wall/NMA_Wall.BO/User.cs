using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NMA_Wall.BO.Extensions;

namespace NMA_Wall.BO
{
    public class User
    {
        public static User[] Users =
        {
            new User("admin", "password", true, true),
            new User("moderator", "password", false, true),
            new User("contributer", "password", true)
        };

        public Guid Id { get; protected set; }

        public bool IsContributer { get; protected set; }
        public bool IsAdmin { get; protected set; }

        public string Username { get; protected set; }
        public string Password { get; protected set; }

        public DateTime DateAdded { get; private set; }

        public User(string username, string password, bool isContributer = false, bool isAdmin = false) : this()
        {
            Username = username;
            Password = password.ComputeHash();
            IsContributer = isContributer;
            IsAdmin = isAdmin;
        }

        public User()
        {
            DateAdded = DateTime.Now;
        }
    }
}
