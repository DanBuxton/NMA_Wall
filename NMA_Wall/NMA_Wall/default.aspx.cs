using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NMA_Wall
{
    public partial class Default : System.Web.UI.Page /*BasePage*/
    {
        private DataLayer.Respository DB { get; set; } = new DataLayer.Respository();

        public string MemorialName { get; private set; }

        public Default()
        {
            PreInit += Default_PreInit;
        }

        private void Default_PreInit(object sender, EventArgs e)
        {
            // Get memorial data from database
            MemorialName = "Shot At Dawn"; /* temp */
        }

        public void BtnPostMessage_Click(object sender, EventArgs e)
        {
            // No JavaScript validation as the user can see it
            bool isImageSelected = false;
            string error = "Error:-";

            if (imgComment.Value != null)
                isImageSelected = true;

            if (txtSubject.Value != null || txtSubject.Value == "")
            {
                if (txtSubject.Value.Length >= 3)
                {
                    if (txtMessage.Text != null || txtMessage.Text == "")
                    {
                        if (txtMessage.Text.Length > 3)
                        {
                            if (selOptions.Value != null)
                            {
                                lblError.Visible = false;
                                // Database code here

                                if (isImageSelected)
                                {
                                    // Database Code for image

                                }
                            }
                            else
                            {
                                // no options selected
                                error += Environment.NewLine + "Please select all options that apply to you today";
                            }
                        }
                        else
                        {
                            // longer message required
                            error += Environment.NewLine + "Message must be longer than 3 characters";
                        }
                    }
                    else
                    {
                        // no message entered
                        error += Environment.NewLine + "Message cannot be empty";
                    }
                }
                else
                {
                    // longer subject required
                    error += Environment.NewLine + "Message subject must be longer than 2 characters";
                }
            }
            else
            {
                // no subject entered
                error += Environment.NewLine + "Message subject cannot be empty";
            }

            if (error != "Error:-")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = error;
                lblError.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnPostMessage.Click += BtnPostMessage_Click;
        }
    }
}