using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NMA_Wall.Admin
{
    public partial class UserAdmin : BasePage
    {
        public UserAdmin()
        {

        }

        private void BtnModCom_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommentModeration.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnModCom.Click += BtnModCom_Click;
        }
    }
}