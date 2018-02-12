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

        public static object Sender { get; set; }

        public Admin()
        {
            Init += Admin_Init;
        }

        private void Admin_Init(object sender, EventArgs e)
        {
            if (BP.LoggedInUser == null || BP.LoggedInUser == new User())
                Logout();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Sender = sender;
        }

        public void Logout(object sender = null, EventArgs e = null)
        {
            Response.Redirect("../Logout.aspx", true);
        }
    }
}