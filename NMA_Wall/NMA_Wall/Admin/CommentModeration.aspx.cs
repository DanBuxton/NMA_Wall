using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NMA_Wall.BO;

namespace NMA_Wall.Admin
{
    public partial class CommentModeration : BasePage
    {
        public List<Message> Messages { get; set; } = new List<Message>();

        private int index;

        protected Message currentMessage;

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
            Messages = new List<Message>(DB.MessageGetAll().Where(m => m.IsAwaitingModeration));

            if (Global.DebugBurton)
            {
                Messages.AddRange(Message.Messages.Where(m => m.IsAwaitingModeration));
            }

            Messages.OrderBy(m => m.Id);

            if (Messages.Count() > 1)
            {
                index = new Random().Next(0, Messages.Count());
                currentMessage = Messages[index];
            }

            if (Global.IsDebug)
            {
                //Response.Write($"(DEBUG) There are {Messages.Count} message{((Messages.Count >= 2) || (Messages.Count == 0) ? "s" : "")}");
                Response.Write($"(DEBUG) There are {Messages.Count} / {Messages.Count()} messages that require moderation");
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
            if (Global.IsDebug)
            {
                Response.Write("<br /><br />Moderating comments now!");
            }

            if (rblIsCommentValid.SelectedItem != null)
            {
                if (rblIsCommentValid.SelectedValue == "Yes")
                {
                    // Valid
                    Messages[index].IsAwaitingModeration = false;
                    Messages[index].IsVaild = true;
                }
                else
                {
                    // Not valid
                    Messages[0].IsAwaitingModeration = false;
                    Messages[0].IsVaild = false;
                }

                DB.SaveChanges();
            }
            else
            {
                // Not selected Yes or No
            }
        }
    }
}