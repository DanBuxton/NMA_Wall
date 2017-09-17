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
            PreInit += UserAdmin_PreInit;
        }

        public void Page_Load(object sender, EventArgs e)
        {
            btnModCom.Click += BtnModCom_Click;
            btnAddUser.Click += BtnAddUser_Click;
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddAccount.aspx");
        }

        private void BtnModCom_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CommentModeration.aspx");
        }

        private void UserAdmin_PreInit(object sender, EventArgs e)
        {
            Page.Title = "Admin";
        }
    }
}