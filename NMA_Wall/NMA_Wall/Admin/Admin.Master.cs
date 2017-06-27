using NMA_Wall.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NMA_Wall.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public User CurrentUser { get; set; }

        public Admin()
        {

        }

        public Admin(User user)
        {
            CurrentUser = user;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}