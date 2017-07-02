using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class User
    {
        public Guid Id { get; protected set; }

        public bool IsSuperAdmin { get; protected set; }
        public bool IsContribruter { get; protected set; }
        public bool IsAdmin { get; protected set; }

        public string Username { get; protected set; }
        public string Password { get; protected set; }

        public User(string username, string password, bool isContribruter = false, bool isAdmin = false, bool isSuperAdmin = false)
        {

        }

        public User()
        {

        }
    }
}
