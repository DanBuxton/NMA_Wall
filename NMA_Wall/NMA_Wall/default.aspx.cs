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
    public partial class Default : System.Web.UI.Page
    {
        public string MemorialName { get; private set; }

        public string ConnectionError { get; set; }

        public Default()
        {
            PreInit += Default_PreInit;
        }

        private void Default_PreInit(object sender, EventArgs e)
        {
            // Get memorial data from database
            MemorialName = "Shot At Dawn";


        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}