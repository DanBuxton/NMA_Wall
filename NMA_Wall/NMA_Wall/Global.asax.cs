using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NMA_Wall.BO;

namespace NMA_Wall
{
    public class Global : HttpApplication
    {
        public static bool IsDebug { get; set; } = false;
        public static bool DebugBurton { get; set; } = false;

        protected void Application_Start(object sender, EventArgs e)
        {
            Settings.RootPathOfWebsite = Server.MapPath("/");

            if (DebugBurton)
                AddBurtonData(isLocal: true);
        }

        //void Application_Error(object sender, EventArgs e)
        //{
        //    // Get last error from the server
        //    Exception exc = Server.GetLastError();

        //    if (exc is HttpException)
        //    {
        //        if (exc.InnerException != null)
        //        {
        //            exc = new Exception(exc.InnerException.Message);
        //            Server.Transfer("Error.aspx?handler=Application_Error%20-%20Global.asax", true);
        //        }
        //    }
        //}

        private void AddBurtonData(bool isLocal = true)
        {
            if (isLocal)
            {
                foreach (var item in BurtonData())
                {
                    Message.Messages.Add(item);
                }
            }
        }

        private Message[] BurtonData()
        {
            List<Message> result = new List<Message>();

            result.Add(new Message(message: "I love this memorial", lat: 52.800428, lon: -1.630986, isAwaitingModeration: false));
            result.Add(new Message(message: "I hate this memorial :angry:", lat: 52.800428, lon: -1.630986));

            return result.ToArray();
        }
    }
}