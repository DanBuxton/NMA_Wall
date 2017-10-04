using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMA_Wall.Admin
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        public DataLayer.Respository DB { get; set; } = new DataLayer.Respository();

        private Guid? LoggedInUserId
        {
            get
            {
                return Session["LoggedInUserId"] == null ? null : (Guid?)Session["LoggedInUserId"];
            }
            set
            {
                Session["LoggedInUserId"] = value;
            }
        }

        public BO.User LoggedInUser
        {
            get
            {
                BO.User result = new BO.User();

                if (LoggedInUserId.HasValue)
                {
                    result = DB.UserGet(LoggedInUserId.Value);
                }

                return result;
            }
            set
            {
                if (LoggedInUser != new BO.User())
                {
                    LoggedInUserId = LoggedInUser.Id;
                }
                else
                {
                    LoggedInUserId = null;
                }
            }
        }
    }
}