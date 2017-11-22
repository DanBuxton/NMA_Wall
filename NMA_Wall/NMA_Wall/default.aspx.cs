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

namespace NMA_Wall
{
    public partial class Default : BasePage
    {
        public Default()
        {
            PreInit += Default_PreInit;

            if (IsPostBack)
            {
                PostBack_Validation();
            }
        }

        private void DisplayMessageBox(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }

        private void Default_PreInit(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void PostBack_Validation()
        {
            // Secondary validation
            //Page.Validate();
            string error = "";

            if (txtSubject.Value != null && txtSubject.Value != "")
            {
                if (txtSubject.Value.Length >= 3)
                {
                    if (txtComment.Value != null && txtComment.Value == "")
                    {
                        if (txtComment.Value.Length > 3)
                        {
                            if (selOptions.Items.Count == 1)
                            {
                                if (fuCommentImage.HasFile &&
                                    (fuCommentImage.FileName.ToLower().EndsWith(".jpg") ||
                                    fuCommentImage.FileName.ToLower().EndsWith(".jpeg")))
                                {
                                    // Database Code for image
                                    BO.Message message = new BO.Message("", -29.367, 125.228, false);
                                    DB.MessageAdd(message);
                                    DB.SaveChanges();
                                    message.SaveImage(fuCommentImage.FileContent);
                                }
                                else
                                {
                                    // Add comment to database
                                    DB.MessageAdd(new BO.Message("", -29.367, 125.228, false));
                                }
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
                }
                else
                {
                    // longer subject required
                    error = "Subject subject must be longer than 2 characters";
                }
            }
            else
            {
                // no subject entered
                error = "Subject subject cannot be empty";
            }

            if (error != "")
            {
                DisplayMessageBox(error);
            }
        }
    }
}