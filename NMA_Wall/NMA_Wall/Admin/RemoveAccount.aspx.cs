using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NMA_Wall.BO;

namespace NMA_Wall.Admin
{
    public partial class RemoveAccount : BasePage
    {
        public List<User> Users { get; set; } = new List<User>();

        public RemoveAccount()
        {
            PreInit += RemoveAccount_PreInit;
        }

        private void RemoveAccount_PreInit(object sender, EventArgs e)
        {
            if (!(LoggedInUser.IsAdmin || LoggedInUser.IsSuperAdmin))
            {
                Response.Redirect(url: "/Admin/UserAdmin.aspx", endResponse: true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRemove.Click += BtnRemove_Click;

            foreach (var user in DB.UserGetAll())
            {
                if ((!(user.IsSuperAdmin || user.IsAdmin) && (LoggedInUser.IsAdmin || LoggedInUser.IsSuperAdmin)) || (user.IsSuperAdmin && LoggedInUser.IsSuperAdmin))
                {
                    if (selUsers.Items.FindByValue(user.Id.ToString()) != null) continue; // Doesn't add duplicates when on PostBack from issue(s)
                    {
                        selUsers.Items.Add(new ListItem(user.Username + " - " + DB.UserGetType(user.Id) + (user == LoggedInUser ? " (You)" : ""), user.Id.ToString()));
                    }
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (selUsers.Value != null && selUsers.Value != "")
            {
                Guid id = new Guid();

                Guid.TryParse(selUsers.Value, out id);

                User user = DB.UserGet(id);

                if (LoggedInUser != user)
                {
                    DB.UserRemove(user);
                }
                else
                {
                    // User removing itself
                }
            }
        }
    }
}