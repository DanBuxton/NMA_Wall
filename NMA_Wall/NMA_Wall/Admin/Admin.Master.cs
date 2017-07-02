using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NMA_Wall.BO;
using NMA_Wall.DataLayer;

namespace NMA_Wall.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public Respository Repo { get; set; } = new Respository();
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