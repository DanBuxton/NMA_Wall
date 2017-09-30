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
        public List<User> Users { get; set; } = new List<BO.User>();

        public RemoveAccount()
        {
            if (!(LoggedInUser.IsAdmin || LoggedInUser.IsSuperAdmin))
            {
                Response.Redirect("/Admin/UserAdmin.aspx", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRemove.Click += BtnRemove_Click;

            foreach (User user in DB.UserGetAll())
            {
                if ((!(user.IsSuperAdmin || user.IsAdmin) && LoggedInUser.IsAdmin) || (!user.IsSuperAdmin && LoggedInUser.IsSuperAdmin))
                {
                    if (user == LoggedInUser) continue;
                    selUsers.Items.Add(new ListItem(user.Username, user.Id.ToString()));
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (selUsers.Value != null && selUsers.Value != "")
            {
                Guid id = new Guid();

                Guid.TryParse(selUsers.Value, out id);

                BO.User user = DB.UserGet(id);

                DB.UserRemove(user);
            }
        }
    }
}