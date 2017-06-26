using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMA_Wall.BO
{
    public class User
    {
        public bool isContribruter { get; protected set; } = false;
        public bool isAdmin { get; protected set; } = false;

        public User()
        {

        }
    }
}
