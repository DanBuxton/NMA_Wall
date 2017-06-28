using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NMA_Wall.BO;
using NMA_Wall.DataLayer;

namespace NMA_Wall
{
    public partial class Login : System.Web.UI.Page
    {
        public Respository Repo { get; set; } = new Respository();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
#if DEBUG

            User user = new User("Admin", "Hi");

            Repo.UserAdd(user);

#endif

            btnSubmit.Click += BtnSubmit_Click;*/
        }

        /*private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!(txtUsername.Text.Length < 5))
            {
                if (!(txtPassword.Text.Length < 5))
                {
                    User user = Repo.UserGet(txtUsername.Text, txtPassword.Text) as User;
                }
            }
        }*/
    }
}