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
    public partial class Admin : BasePage
    {
        public Admin()
        {
            Init += Admin_Init;
        }

        private void Admin_Init(object sender, EventArgs e)
        {
            if (LoggedInUser == null)
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LoggedInUser = new User();
            BasePage bp = new BasePage();
            bp.LoggedInUser = new User();
            
            //Response.Redirect("../Default.aspx");
        }
    }
}