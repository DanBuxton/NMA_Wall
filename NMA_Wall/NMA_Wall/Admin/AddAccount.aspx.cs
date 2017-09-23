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
#if DEBUG
            // For Testing purposes only
            if (!DB.UserDoesExist("BSDCDeveloper", "NMA_User"))
                DB.UserAdd(new BO.User("BSDCDeveloper", "BSDCDeveloper", isSuperAdmin: true));
#endif

            btnUserAdd.Click += BtnUserAdd_Click;
        }

        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            string defaultPassword = "NMA_User";

            if (txtUsername.Text != "" && txtUsername.Text.Length >= 5) // Has entered OK username
            {
                if (selAccountType.Value != null) // Has selected account type
                {
                    BO.User user = new BO.User();

                    if (!DB.UserDoesExist(txtUsername.Text, defaultPassword))
                    {
                        if (selAccountType.Value == "Contributor")
                            user = new BO.User(txtUsername.Text, defaultPassword, isContribruter: true);
                        else if (selAccountType.Value == "Admin")
                            user = new BO.User(txtUsername.Text, defaultPassword, isAdmin: true);
                        else if (selAccountType.Value == "Super_Admin")
                            user = new BO.User(txtUsername.Text, defaultPassword, isSuperAdmin: true);

                        if (Request.IsLocal)
                            Response.Write("Adding user");

                        DB.UserAdd(user);

                        if (Request.IsLocal)
                            Response.Write("User added");
                    }
                    else // Username already exists
                    {
                        if (Request.IsLocal)
                            Response.Write("User already exists");
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