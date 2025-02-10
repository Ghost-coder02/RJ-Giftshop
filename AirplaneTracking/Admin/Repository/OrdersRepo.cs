using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AirplaneTracking.Admin.Models;
using AirplaneTracking.Admin.Repository;

namespace AirplaneTracking.Customer.Repository
{
    public class OrdersRepo
    {
        public SqlConnection GetConnection()
        {
            // This line retrieves the connection string named "MyDb" from the application's web.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }




        public List<Orders> GetOrders()
        {
            List<Orders> ListOfOrders = new List<Orders>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                    o.Order_id AS OrderID, 
		                            c.FName, 
		                            c.LName, 
		                            c.Phone, 
		                            o.Prods_count, 
		                            o.Total_price, 
		                            o.Delivery_status AS Status, 
		                            o.Created_at
                                FROM OrderDetails as o 
                                INNER JOIN Customer as c
                                    ON c.Cust_id = o.Cust_id";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Orders order = new Orders()
                        {

                            OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),

                            CustomerObj = new Admin.Models.Customer
                            {
                                FName = reader.GetString(reader.GetOrdinal("FName")),
                                LName = reader.GetString(reader.GetOrdinal("LName")),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("Phone")) ? default : reader.GetString(reader.GetOrdinal("Phone")),

                            },

                            ProdsCount = reader.GetInt32(reader.GetOrdinal("Prods_count")),

                            TotalPrice = reader.GetDecimal(reader.GetOrdinal("Total_price")),

                            OrderStatus = reader.GetBoolean(reader.GetOrdinal("Status")),

                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("Created_at"))

                        };

                        ListOfOrders.Add(order);
                    }
                }
            }
            return ListOfOrders;
        }




        public void UpdateStatus(int OrderID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE OrderDetails 
                                 SET Delivery_status = 1
                                 WHERE Order_id = @OrderID;
                                   ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    cmd.ExecuteNonQuery();
                }

            }
        }





        public List<Products> GetOrderProducts(int OrderID)
        {
            List<Products> OrderProducts = new List<Products>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT
							p.Prod_id, 
                            p.[Name] AS ProdName,
							s.[Name] AS SizeName , 
							p.Col_id , 
							p.Material, 
							op.Old_price, 
							op.Discount, 
							op.New_price, 
                            op.Prod_quant,
                            op.Prod_price
                       FROM Product AS p
                       JOIN Size s ON p.Size_id= s.Size_id
                       JOIN Order_Products AS op ON op.Prod_id = p.Prod_id
                       WHERE Order_id = @OrderID;";

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Products product = new Products()
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("Prod_id")),
                            ProdName = reader.IsDBNull(reader.GetOrdinal("ProdName")) ? default : reader.GetString(reader.GetOrdinal("ProdName")),

                            SizeObj = new Size
                            {
                                SizeName = reader.GetString(reader.GetOrdinal("SizeName")),
                            },

                            Color = reader.GetString(reader.GetOrdinal("Col_id")),

                            Material = reader.IsDBNull(reader.GetOrdinal("Material")) ? default : reader.GetString(reader.GetOrdinal("Material")),

                            
                            OrderProdObj = new OrderProducts
                            {
                                OldPrice = reader.GetDecimal(reader.GetOrdinal("Old_price")),
                                Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? default : reader.GetDecimal(reader.GetOrdinal("Discount")),
                                NewPrice = reader.GetDecimal(reader.GetOrdinal("New_price")),
                                ProdQuant = reader.GetInt32(reader.GetOrdinal("Prod_quant")),
                                ProdPrice = reader.GetDecimal(reader.GetOrdinal("Prod_price"))
                            }
                        };
                        OrderProducts.Add(product);
                    }
                }
            }
            return OrderProducts;
        }




        public List<Orders> GetCustOrderInfo(int OrderID)
        {
            List<Orders> info = new List<Orders>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT o.Order_id,
	                                o.Total_price, 
	                                o.Created_at, 
	                                c.FName, 
	                                c.LName, 
	                                c.Country, 
	                                c.Phone, 
	                                c.Address 
                                FROM OrderDetails AS o
                                JOIN Customer AS c ON c.Cust_id = o.Cust_id;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Orders order = new Orders()
                        {
                            OrderID = reader.GetInt32(reader.GetOrdinal("Order_id")),
                            TotalPrice = reader.GetDecimal(reader.GetOrdinal("Total_price")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("Created_at")),
                            CustomerObj = new Admin.Models.Customer
                            {
                                FName = reader.GetString(reader.GetOrdinal("FName")),
                                LName = reader.GetString(reader.GetOrdinal("LName")),
                                Country = reader.GetString(reader.GetOrdinal("Country")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("Phone")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? default : reader.GetString(reader.GetOrdinal("Address"))
                            }
                        };

                        info.Add(order);
                    }
                }
            }
            return info;
        }





    }
}