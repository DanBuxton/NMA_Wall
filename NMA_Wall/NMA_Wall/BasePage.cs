using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMA_Wall
{
    public class BasePage : System.Web.UI.Page
    {
        public DataLayer.Respository DB { get; set; } = new DataLayer.Respository();

        private string LoggedInUserName
        {
            get
            {
                return Session["LoggedInUserName"] == null ? null : (string)Session["LoggedInUserName"];
            }
            set
            {
                Session["LoggedInUserName"] = value;
            }
        }
        
        public BO.User LoggedInUser
        {
            get
            {
                BO.User result = new BO.User();

                if (LoggedInUserName != null)
                {
                    result = BO.User.Users.FirstOrDefault(u => u.Username == LoggedInUserName);
                }

                return result;
            }
            set
            {
                if (value != null)
                {
                    LoggedInUserName = value.Username;
                }
                else
                {
                    LoggedInUserName = null;
                }
            }
        }
    }
}