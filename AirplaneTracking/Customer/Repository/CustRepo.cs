using AirplaneTracking.Customer.Layout.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace AirplaneTracking.Customer.Repository
{
    public class CustRepo
    {

        public SqlConnection GetConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                return conn;
            }
            catch (SqlException ex)
            {
                // Log or print the exception details
                Console.WriteLine($"Database connection failed: {ex.Message}");
                throw; // Re-throw the exception if needed
            }
            
        }








        public List<Customer.Models.Customer> GetCustInfo(string Username)
        {

            List<Customer.Models.Customer> Cust = new List<Customer.Models.Customer>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customer WHERE Username=@Username";
                using(SqlCommand cmd= new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Customer.Models.Customer CustObj = new Customer.Models.Customer()
                        {
                            CustId = reader.GetInt32(reader.GetOrdinal("Cust_id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FName")),
                            LastName = reader.GetString(reader.GetOrdinal("LName")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            Password = reader.GetString(reader.GetOrdinal("Password")),
                            //Gender = reader.getchar
                            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("Date_of_birth")),
                            Country = reader.GetString(reader.GetOrdinal("Country")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? default : reader.GetString(reader.GetOrdinal("Address")),
                            CreatedAt = reader.IsDBNull(reader.GetOrdinal("CreatedAt")) ? default : reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) ? default : reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                            DeletedAt = reader.IsDBNull(reader.GetOrdinal("DeletedAt")) ? default : reader.GetDateTime(reader.GetOrdinal("DeletedAt"))
                        };

                        Cust.Add(CustObj);
                            
                    }
                }
            }
            return Cust;
        }



        //public Customer.Models.Customer[] GetCustInfo(string Username)
        //{
        //    List<Customer.Models.Customer> Cust = new List<Customer.Models.Customer>();

        //    using (SqlConnection conn = GetConnection())
        //    {
        //        conn.Open();

        //        string query = "SELECT * FROM CUSTOMER WHERE Username=@Username";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue(Username, Username);

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Customer.Models.Customer CustObj = new Customer.Models.Customer()
        //                {
        //                    CustId = reader.GetInt32(reader.GetOrdinal("Cust_id")),
        //                    FirstName = reader.GetString(reader.GetOrdinal("FName")),
        //                    LastName = reader.GetString(reader.GetOrdinal("LName")),
        //                    Username = reader.GetString(reader.GetOrdinal("Username")),
        //                    Password = reader.GetString(reader.GetOrdinal("Password")),
        //                    //Gender = reader.getchar
        //                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("Date_of_birth")),
        //                    Country = reader.GetString(reader.GetOrdinal("Country")),
        //                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
        //                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? default :  reader.GetString(reader.GetOrdinal("Address")),
        //                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
        //                    UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) ? default : reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
        //                    DeletedAt = reader.IsDBNull(reader.GetOrdinal("DeletedAt")) ? default : reader.GetDateTime(reader.GetOrdinal("DeletedAt"))

        //                };



        //                Cust.Add(CustObj);


        //            }

        //        }
        //    }
        //        return Cust.ToArray();

        //}






    }
}