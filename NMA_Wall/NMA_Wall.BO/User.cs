using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class User
    {
        public bool IsContribruter { get; protected set; } = false;
        public bool IsAdmin { get; protected set; } = false;
        public bool IsAnonymous { get; set; } = true;
        public bool IsSuperAdmin { get; set; }

        public User()
        {

        }
    }
}
