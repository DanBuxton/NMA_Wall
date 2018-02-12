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
            if (Global.DebugBurton)
                Messages.AddRange(Message.Messages.Where(m => m.IsAwaitingModeration));
            else
            {
                Messages = new List<Message>(DB.MessageGetAll().Where(m => m.IsAwaitingModeration));
            }

            Messages.OrderBy(m => m.Id);

            if (Messages.Count() > 1)
            {
                index = new Random().Next(0, Messages.Count());
                currentMessage = Messages[index];
            }
            else if (Messages.Count() == 1)
            {
                index = 0;
                currentMessage = Messages[index];
            }

            if (Global.IsDebug)
            {
                //Response.Write($"(DEBUG) There are {Messages.Count} message{((Messages.Count >= 2) || (Messages.Count == 0) ? "s" : "")}");
                Response.Write($"(DEBUG) There are {Messages.Count(m => m.IsAwaitingModeration)} / {DB.MessageGetAll().Count() + Message.Messages.Count()} messages that require moderation");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    ModerateComments();

            //    Response.Redirect("CommentModeration.aspx", true);
            //}

            btnModerateComments.Click += BtnModerateComments_Click;
        }

        private void BtnModerateComments_Click(object sender, EventArgs e)
        {
            Debug.Write(value: "Button handler", category: "Location");

            ModerateComments();

            Response.Redirect("CommentModeration.aspx", true);
        }

        private void ModerateComments()
        {
            Debug.Write(value: "Moderating comments", category: "Location");

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