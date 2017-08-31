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
    public partial class Default : System.Web.UI.Page /*BasePage*/
    {
        // Database Access
        private DataLayer.Respository DB { get; set; } = new DataLayer.Respository();

        public string MemorialName { get; private set; }

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
            // Get memorial name, details and comments from ajax
            MemorialName = "Shot At Dawn"; /* temp */
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void PostBack_Validation()
        {
            // Secondary validation
            //Page.Validate();
            bool isImageSelected = false;
            string error = "";

            if (imgComment.Value != null)
                isImageSelected = true;

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
                                if (isImageSelected)
                                {
                                    // Database Code for image

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