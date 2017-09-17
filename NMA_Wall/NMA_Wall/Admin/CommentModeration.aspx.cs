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
            //GetUnmoderatedComments();
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}