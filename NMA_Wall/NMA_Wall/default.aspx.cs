using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NMA_Wall.BO.Extensions;
using System.Collections;

namespace NMA_Wall
{
    public partial class Default : BasePage
    {
        public Default()
        {
            PreInit += Default_PreInit;
        }

        public void DisplayMessageBox(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }

        private void Default_PreInit(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //AddComments(lat: -29.367, lon: 125.228);
            AddComments(-29.367, 125.228);

            btnSubmit.ServerClick += (s, r) =>
            {
                PostNewComment();
            };
        }

        private void AddComments(double lat, double lon, double dist = 10)
        {
            var commentsDB = DB.MessageGetInRange(lat, lon, dist);

            if (commentsDB.Count() >= 0)
            {
                var validComments = commentsDB.Where(m => m.IsVaild).OrderByDescending(m => m.DateAdded);
                //var validComments = BO.Message.Messages.Where(m => m.IsVaild);
                var speechMarck = '"';
                string result = string.Empty;

                if (Global.IsDebug)
                    result += $"Comments: {validComments.Count()}";

                foreach (BO.Message message in validComments)
                {
                    result += $"<hr />";

                    result += $"<section class={speechMarck}comment{speechMarck}>";
                    result += $"<p>";

                    if (message.HasImage)
                        result += $"<img src={speechMarck}img/Comments/{message.Id}.jpg{speechMarck} " +
                                        $"width={speechMarck}150{speechMarck} " +
                                        $"height={speechMarck}150{speechMarck} " +
                                        $"class={speechMarck}image{speechMarck} />";
                    else
                        result += message.MessageBody;

                    result += $"</p>";

                    result += $"<p class={speechMarck}message-details{speechMarck}>" +
                        $"Posted by anonymous at {message.DateAdded.Hour.ToString()}:{message.DateAdded.Minute.ToString()} " +
                        (message.DateAdded.Year != DateTime.Now.Year ?
                        message.DateAdded.ToString("dddd, dnn MMM yy", useExtendedSpecifiers: true) :
                        message.DateAdded.ToString("dddd, dnn MMM", useExtendedSpecifiers: true));

                    result += "</section>";
                }

                result += $"<hr />";

                comments.InnerHtml = result;
            }
        }

        private void PostNewComment()
        {
            string error = "";

            if ((txtComment.Value != null && txtComment.Value != "") || (fuCommentImage.HasFile))
            {
                if ((txtComment.Value.Length > 3) || (fuCommentImage.HasFile))
                {
                    if (selOptions.Value != null)
                    {
                        if (fuCommentImage.HasFile &&
                            (fuCommentImage.FileName.ToLower().EndsWith(".jpg") ||
                            fuCommentImage.FileName.ToLower().EndsWith(".jpeg")))
                        {
                            // Database Code for image
                            BO.Message message = new BO.Message(txtComment.Value, -29.367, 125.228); // alter location once AJAX sorted
                            DB.MessageAdd(message);
                            DB.SaveChanges();

                            message.SaveImage(fuCommentImage.FileContent);
                        }
                        else
                        {
                            // Add comment to database
                            DB.MessageAdd(new BO.Message(txtComment.Value, -29.367, 125.228)); // alter location once AJAX sorted
                        }

                        DB.SaveChanges();
                        Form.Controls.Clear();
                    }
                    else
                    {
                        // no options selected
                        error = "Please select all options that apply to you today";
                    }
                }
                else
                {
                    // longer message required
                    error = "Comment must be longer than 3 characters";
                }
            }
            else
            {
                // no message entered
                error = "Comment cannot be empty";
            }

            if (error != "")
            {
                DisplayMessageBox(error);
            }

            Response.Redirect("/", true); //Prevent a post-back 
        }
    }
}
