using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NMA_Wall.Admin
{
    public partial class AddAccount : BasePage
    {
        public AddAccount()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsLocal)
                Response.Write("Hello Add User Page");
            btnUserAdd.Click += BtnUserAdd_Click;
        }

        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            string defaultPassword = "NMA_User";

            if (txtUsername.Text != "" && txtUsername.Text.Length >= 5) // Has entered OK username
            {
                if (Request.IsLocal)
                    Response.Write("Good username");

                if (selAccountType.Value != null) // Has selected account type
                {
                    BO.User user = new BO.User();

                    if (!DB.UserDoesExist(txtUsername.Text, defaultPassword))
                    {
                        if (selAccountType.Value == "Contributer")
                            user = new BO.User(txtUsername.Text, defaultPassword, isContribruter: true);
                        else if (selAccountType.Value == "Admin")
                            user = new BO.User(txtUsername.Text, defaultPassword, isAdmin: true);
                        else if (selAccountType.Value == "Super_Admin")
                            user = new BO.User(txtUsername.Text, defaultPassword, isSuperAdmin: true);

                        if (Request.IsLocal)
                            Response.Write("Bad account type");

                        DB.UserAdd(user);
                    }
                }
                else // Rubbish account type
                {
                    if (Request.IsLocal)
                        Response.Write("Bad account type");
                }
            }
            else // Rubbish username
            {
                if (Request.IsLocal)
                    Response.Write("Bad username");
            }
        }
    }
}