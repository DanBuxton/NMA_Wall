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
    public partial class Admin : MasterPage //BasePage
    {
        public BasePage BP { get; set; } = new BasePage();

        public Admin()
        {
            Init += Admin_Init;
        }

        private void Admin_Init(object sender, EventArgs e)
        {
            if ((BP.LoggedInUser == new User()) || (BP.LoggedInUser == null))
            {
                Logout();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogout.ServerClick += (s, r) =>
            {
                Logout();
            };
        }

        private void Logout()
        {
            Response.Redirect("../Logout.aspx");
        }
    }
}