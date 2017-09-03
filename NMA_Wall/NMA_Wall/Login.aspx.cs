using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NMA_Wall.BO;
using NMA_Wall.DataLayer;
using NMA_Wall.BO.Extensions;

namespace NMA_Wall
{
    public partial class Login : BasePage
    {
        public Login()
        {
            PreInit += Login_PreInit;
        }

        private void Login_PreInit(object sender, EventArgs e)
        {
            // Auto-Login
            if (LoggedInUser != null)
                Response.Redirect("/Admin/UserAdmin.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != null)
            {
                if (txtPassword.Text != null)
                {
                    // if (DB.UserGet(txtUsername.Text, txtPassword.Text.ComputeHash()) != null)
                    // {

                    // Database Login Here -> direct user to '/Admin/' with the current user
                    //   DB.UserGet Hashes password
                    User user = DB.UserGet(txtUsername.Text, txtPassword.Text);

                    if (user != null)
                    {
                        // Make sure user details are on the BasePage
                        LoggedInUser = user;

                        if (user.IsAdmin || user.IsSuperAdmin)
                        {
                            Response.Redirect("/Admin/UserAdmin.aspx");
                        }
                        else if (user.IsContribruter)
                        {
                            Response.Redirect("/Admin/UserContribruter.aspx"); // Does not exist yet
                        }
                        else
                        {
                            // User not set up correct
                        }
                    }

                    // }

                    /*
                    User user = new User();

                    if (DB.UserGet(txtUsername.Text, txtPassword.Text) != null)
                    {
                        user = DB.UserGet(txtUsername.Text, txtPassword.Text);
                    }
                    /**/
                }
            }
        }
    }
}