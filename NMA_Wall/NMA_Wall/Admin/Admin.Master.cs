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
    public partial class Admin : BaseMasterPage
    {
        public Admin()
        {

        }

        private void BtnLogout_ServerClick(object sender, EventArgs e)
        {
            LoggedInUser = null;
            
            Response.Redirect("../Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}