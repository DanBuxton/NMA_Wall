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
            new User("contributor", "password", true)
        };

        public Guid Id { get; protected set; }

        public bool IsContributor { get; protected set; }
        public bool IsAdmin { get; protected set; }

        public string Username { get; protected set; }
        public string Password { get; protected set; }

        public DateTime DateAdded { get; private set; }

        public User(string username, string password, bool isContributor = false, bool isAdmin = false) : this()
        {
            Username = username;
            Password = password.ComputeHash();
            IsContributor = isContributor;
            IsAdmin = isAdmin;
        }

        public User()
        {
            DateAdded = DateTime.Now;
        }
    }
}
