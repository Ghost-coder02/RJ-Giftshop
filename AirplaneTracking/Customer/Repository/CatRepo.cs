using System;
using System.Collections.Generic;
using System.Linq;  // It includes classes like SqlConnection, SqlCommand, and SqlDataReader used in this code.
using System.Web;

using System.Data; //  used for accessing and managing data from databases. DataTable
using System.Data.SqlClient;
using System.Configuration; // to access the application's configuration settings, specifically the connection string from the web.config file.


namespace AirplaneTracking.Customer.Repository
{
    public class CatRepo
    {

        public SqlConnection GetConnection()
        {
            // to retrieve the connectionString named as MyDb from the database
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }




        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT * from [Categories]";

                using (SqlCommand cmd = new SqlCommand(query, conn)) // executes the query
                {
                    using (SqlDataReader data = cmd.ExecuteReader()) // This executes the SQL query and returns a SqlDataReader object

                    {
                        dt.Load(data);

                    }
                }
            }

            return dt;

        }

        /*****************************************************

        public byte[] GetImage()
        {
            byte[] imageData;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT * from [Categories]";

                using (SqlCommand cmd = new SqlCommand(query, conn)) // executes the query
                {
                    imageData = cmd.ExecuteScalar() as byte[];
                    imageData = (byte[])cmd.ExecuteScalar();

                }

                return imageData;
            }
        }*/



    }
}