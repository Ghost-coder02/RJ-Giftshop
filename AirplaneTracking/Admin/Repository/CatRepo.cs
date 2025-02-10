using AirplaneTracking.Admin.Models;
using System.Collections.Generic;
using System.Configuration; // to access the application's configuration settings, specifically the connection string from the web.config file.
using System.Data; //  used for accessing and managing data from databases. DataTable
using System.Data.SqlClient;
using System.Linq; // It includes classes like SqlConnection, SqlCommand, and SqlDataReader used in this code.

namespace AirplaneTracking.Admin.Repository
{
    public class CatRepo // This is the class that contains the method to retrieve data from the database.
    {

        public SqlConnection GetConnection()
        {
            // This line retrieves the connection string named "MyDb" from the application's web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
        



        public DataTable GetCategories()  // method that returns a DataTable containing the results of the query.
        {
     
            DataTable dt = new DataTable(); // creates a new DataTable object to hold the data that will be retrieved from the database.


            using (SqlConnection conn = GetConnection())
            {
                conn.Open(); //Opens the database connection
                string query = "SELECT * from [Categories]";



                using(SqlCommand cmd= new SqlCommand(query, conn)) // executes the query
                {
                    using (SqlDataReader data = cmd.ExecuteReader()) // This executes the SQL query and returns a SqlDataReader object
                    {
                        dt.Load(data);
                    }
                }
            }
                
            return dt;
        }


        public void EditCat(int CategID, string CategName)
        {
            
            
        }
       


        public void DeleteCat(int CategID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM [Categories] WHERE Cat_id = @CategoryID";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", CategID); // TO AVOID SQL INJECTION
                    cmd.ExecuteNonQuery();
                }
            }
            
        }


        public void UpdateCat(int CategID, string CategName)
        {

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE [Categories] SET Name = @CategoryName WHERE Cat_id = @CategoryID";

                using (SqlCommand cmd = new SqlCommand(query,conn))
                {
            
                    //cmd.CommandText = CommandType.StoredProcedure();

                    cmd.Parameters.AddWithValue("@CategoryName", CategName);
                    cmd.Parameters.AddWithValue("@CategoryID", CategID);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AddCat(string CategName)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"insert INTO Categories(Name) VALUES(@CategoryName);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", CategName);

                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}



// GetConnection
// GetCategories
// EditCat
// DeleteCat
// UpdateCat
// AddCat
