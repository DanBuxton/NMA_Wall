﻿using System;
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
            DB.SaveChanges();

            //AddComments(lat: -29.367, lon: 125.228);
            //AddComments(-29.367, 125.228);
            AddComments(lat: -29.367, lon: 125.228);

            btnSubmit.ServerClick += (s, r) =>
            {
                PostNewComment();
            };
        }

        /// <summary>
        /// Display commments to the user. 
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <param name="dist">the +- of location</param>
        private void AddComments(double lat, double lon, double dist = 10)
        {
            // Get all comments that have been moderated
            var commentsDB = DB.MessageGetInRange(lat, lon, dist).Where(m => !m.IsAwaitingModeration);

            if (commentsDB.Count() >= 1)
            {
                var validComments = commentsDB.OrderByDescending(m => m.DateAdded);
                //var validComments = BO.Message.Messages.Where(m => m.IsVaild);
                var speechMarck = '"';
                string result = string.Empty;

                if (Global.IsDebug || false)
                {
                    result += $"<p>Comments: {validComments.Count()}</p>";
                    result += $@"<p>Image Path: {BO.Settings.RootPathOfWebsite}img\Comments\</p>";
                }

                foreach (BO.Message message in validComments)
                {
                    result += $"<hr />";

                    result += $"<section class={speechMarck}comment{speechMarck}>";
                    result += $"<p>";

                    if (message.HasImage)
                    {
                        result += $"<img src={speechMarck}img/Comments/{message.Id}.jpg{speechMarck} " +
                                        $"width={speechMarck}150{speechMarck} " +
                                        $"height={speechMarck}150{speechMarck} " +
                                        $"class={speechMarck}image{speechMarck} />";
                    }
                    else
                    { result += message.MessageBody; }

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
                            Uri myUri = new Uri(HttpContext.Current.Request.Url.ToString());
                            string lat = HttpUtility.ParseQueryString(myUri.Query).Get("lat");
                            string lng = HttpUtility.ParseQueryString(myUri.Query).Get("lng");

                            // Add comment to database
                            DB.MessageAdd(new BO.Message(txtComment.Value, Convert.ToDouble(lat), Convert.ToDouble(lng))); // alter location once AJAX sorted

                            //lat: -29.367
                            //lng: 125.228
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
