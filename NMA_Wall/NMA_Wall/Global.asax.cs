using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace NMA_Wall
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BO.Settings.RootPathOfWebsite = Server.MapPath("~/");
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Get last error from the server
            Exception exc = Server.GetLastError();

            if (exc is HttpException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer("Error.aspx?handler=Application_Error%20-%20Global.asax", true);
                }
            }
        }
    }
}