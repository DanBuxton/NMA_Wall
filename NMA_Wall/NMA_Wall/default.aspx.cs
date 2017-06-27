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
            // Temp SQL Server connect
            SQLServerConnect();

            // Get memorial data from database
            MemorialName = "Shot At Dawn";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SQLServerConnect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "nma.database.windows.net"; // Server
                builder.UserID = "NMA_Wall"; // Username
                builder.Password = "andy-123"; // Password
                builder.InitialCatalog = "nma_wall"; // Database name

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    //Console.WriteLine("\nQuery data example:");
                    //Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * ");
                    sb.Append("FROM [Messages]");
                    //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ConnectionError += "{0} {1} " + reader.GetString(0) + " : " + reader.GetString(0);
                                // Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                //Console.WriteLine(e.ToString());

                ConnectionError += "Error:-" + Environment.NewLine;

                ConnectionError = e.Message;
            }
        }
    }
}