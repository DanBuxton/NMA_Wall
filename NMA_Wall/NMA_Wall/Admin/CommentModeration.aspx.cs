using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NMA_Wall.Admin
{
    public partial class CommentModeration : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* ERROR
             * 
             * A network-related or instance-specific error occurred while establishing a 
             * connection to SQL Server. The server was not found or was not accessible. 
             * Verify that the instance name is correct and that SQL Server is configured 
             * to allow remote connections. (provider: SQL Network Interfaces, 
             * error: 26 - Error Locating Server/Instance Specified)
             * 
             */
            
            // BO.Message[] messages = (BO.Message[])DB.MessageGetAwaitingModeration();
        }
    }
}