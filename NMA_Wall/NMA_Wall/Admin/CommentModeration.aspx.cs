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
        public List<BO.Message> Messages { get; set; } = new List<BO.Message>();

        public CommentModeration()
        {
            PreInit += CommentModeration_PreInit;
        }

        private void CommentModeration_PreInit(object sender, EventArgs e)
        {
            GetUnmoderatedComments();
        }

        private void GetUnmoderatedComments()
        {
            BO.Message[] messages = DB.MessageGetAll().ToArray();

            foreach (BO.Message message in messages)
            {
                if (!message.IsAwaitingModeration) continue;
                {
                    Messages.Add(message);
                }
            }

            if (Global.DebugBurton)
            {
                // BO.Message.Messages contains if DEBUG
                foreach (BO.Message message in BO.Message.Messages)
                {
                    if (!message.IsAwaitingModeration) continue;
                    {
                        // Messages.Add(message);
                    }

                    // DB.MessageAdd(message);
                }
            }

            if (Global.IsDebug || Global.DebugBurton)
            {
                //Response.Write($"(DEBUG) There are {Messages.Count} message{((Messages.Count >= 2) || (Messages.Count == 0) ? "s" : "")}");
                Response.Write($"(DEBUG) There are {Messages.Count} / {messages.Count()} messages that require moderation");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ModerateComments();
            }
        }

        private void ModerateComments()
        {
            Response.Write("<br /><br />Moderating comments now!");


        }
    }
}