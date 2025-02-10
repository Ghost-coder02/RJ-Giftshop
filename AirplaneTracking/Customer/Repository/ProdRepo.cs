using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
//using AirplaneTracking.Admin.Layout;
using AirplaneTracking.Customer.Layout.Shared;
using AirplaneTracking.Customer.Models;



namespace AirplaneTracking.Customer.Repository
{
    public class ProdRepo
    {

        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }



        public List<Customer.Models.Products> GetProducts(int CatId)
        {
            List<Customer.Models.Products> products = new List<Customer.Models.Products>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // The @ sign allows the string to be written as-is, without needing to escape special characters like backslashes.
                string query = @" SELECT 

					   p.Prod_id, 
                            p.[Name] AS ProdName,
							c.[Name] AS CatName,
							p.Size_id, 
							s.[Name] AS SizeName , 
							p.Col_id , 
							p.Material, 
							p.Quantity, 
							p.Old_price, 
							p.Discount, 
							p.New_price, 
							p.[Description], 
							p.Available_f, 
							p.Created_at, 
							p.Updated_at, 
							p.Deleted_at, 
							p.Is_Active 
							
					   FROM 
							Product p
					   INNER JOIN 
							Size s
						ON
							p.Size_id  = s.Size_id  
                       INNER JOIN
							Categories c
                       ON
                            p.Cat_id= c.Cat_id
					   WHERE 
							p.Cat_id= @CatId
                       ";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CatId", CatId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        Customer.Models.Products product = new Customer.Models.Products()
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("Prod_id")),
                            ProdName = reader.IsDBNull(reader.GetOrdinal("ProdName")) ? default : reader.GetString(reader.GetOrdinal("ProdName")),

                            CategoriesObj = new Customer.Models.Categories
                            {
                                //CatId = reader.GetInt32(reader.GetOrdinal("Cat_id")),

                                // retrieved as CategoryName from the database
                                CatName = reader.GetString(reader.GetOrdinal("CatName"))
                            },

                            Color = reader.GetString(reader.GetOrdinal("Col_id")),

                            Material = reader.IsDBNull(reader.GetOrdinal("Material")) ? default : reader.GetString(reader.GetOrdinal("Material")),

                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),

                            OldPrice = reader.GetDecimal(reader.GetOrdinal("Old_price")),

                            Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? default : reader.GetDecimal(reader.GetOrdinal("Discount")),

                            NewPrice = reader.IsDBNull(reader.GetOrdinal("New_price")) ? default : reader.GetDecimal(reader.GetOrdinal("New_price")),

                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? default : reader.GetString(reader.GetOrdinal("Description")),

                            Available = reader.GetBoolean(reader.GetOrdinal("Available_f")),

                            IsActive = reader.GetBoolean(reader.GetOrdinal("Is_Active"))
                        };

                        products.Add(product);
                    }


                }
            }
            return products;
        }




        public List<Customer.Models.Products> GetRandProds()
        {
            List<Customer.Models.Products> products = new List<Customer.Models.Products>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // The @ sign allows the string to be written as-is, without needing to escape special characters like backslashes.
                string query = @" SELECT 
							p.Prod_id, 
                            p.[Name] AS ProdName,
							c.Cat_id, 
							c.[Name] AS CategoryName, 
							p.Size_id, 
							s.[Name] AS SizeName , 
							p.Col_id , 
							p.Material, 
							p.Quantity, 
							p.Old_price, 
							p.Discount, 
							p.New_price, 
							p.[Description], 
							p.Available_f, 
							p.Created_at, 
							p.Updated_at, 
							p.Deleted_at, 
							p.Is_Active 
                       FROM Product p
                       JOIN Categories c ON p.Cat_id = c.Cat_id
                       JOIN Size s ON p.Size_id= s.Size_id
                       ";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        Customer.Models.Products product = new Customer.Models.Products()
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("Prod_id")),
                            ProdName = reader.IsDBNull(reader.GetOrdinal("ProdName")) ? default : reader.GetString(reader.GetOrdinal("ProdName")),

                            CategoriesObj = new Customer.Models.Categories
                            {
                                CatId = reader.GetInt32(reader.GetOrdinal("Cat_id")),

                                // retrieved as CategoryName from the database
                                CatName = reader.GetString(reader.GetOrdinal("CategoryName"))
                            },

                            Color = reader.GetString(reader.GetOrdinal("Col_id")),

                            Material = reader.IsDBNull(reader.GetOrdinal("Material")) ? default : reader.GetString(reader.GetOrdinal("Material")),

                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),

                            OldPrice = reader.GetDecimal(reader.GetOrdinal("Old_price")),

                            Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? default : reader.GetDecimal(reader.GetOrdinal("Discount")),

                            NewPrice = reader.IsDBNull(reader.GetOrdinal("New_price")) ? default : reader.GetDecimal(reader.GetOrdinal("New_price")),

                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? default : reader.GetString(reader.GetOrdinal("Description")),

                            Available = reader.GetBoolean(reader.GetOrdinal("Available_f")),

                            IsActive = reader.GetBoolean(reader.GetOrdinal("Is_Active"))
                        };

                        products.Add(product);
                    }


                }
            }
            return products;
        }




        /************************************** Cart methods ********************************************************/


        public List<Products> DisplayCart(int CustID)
        {
            List<Products> CartProducts = new List<Products>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // The @ sign allows the string to be written as-is, without needing to escape special characters like backslashes.
                string query = @" SELECT 
							p.Prod_id, 
                            p.[Name] AS ProdName,
                            p.Size_id,
							p.Old_price, 
							p.Discount, 
							p.New_price, 
                            p.Available_f, 
                            p.Is_Active,
							c.Cust_id, 
							c.Quantity, 
							p.Col_id ,
                            c.Cart_id,
                            c.Quantity as Quantity
                       FROM Cart c
                       JOIN Customer cu ON c.Cust_id = cu.Cust_id
                       JOIN Product p ON c.Prod_id= p.Prod_id
                       WHERE c.Cust_id=@CustID
                       ";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustID", CustID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        Products product = new Products()
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("Prod_id")),

                            CartObj = new Cart
                            {
                                CartID = reader.GetInt32(reader.GetOrdinal("Cart_id")),
                                CartQuant = reader.GetInt32(reader.GetOrdinal("Quantity")),
                            },

                            ProdName = reader.IsDBNull(reader.GetOrdinal("ProdName")) ? default : reader.GetString(reader.GetOrdinal("ProdName")),

                            Color = reader.GetString(reader.GetOrdinal("Col_id")),

                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),

                            OldPrice = reader.GetDecimal(reader.GetOrdinal("Old_price")),

                            Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? default : reader.GetDecimal(reader.GetOrdinal("Discount")),

                            NewPrice = reader.IsDBNull(reader.GetOrdinal("New_price")) ? default : reader.GetDecimal(reader.GetOrdinal("New_price")),

                            Available = reader.GetBoolean(reader.GetOrdinal("Available_f")),

                            IsActive = reader.GetBoolean(reader.GetOrdinal("Is_Active")),




                        };

                        CartProducts.Add(product);
                    }


                }
            }
            return CartProducts;
        }



        public void AddToCart(string ProductID, int CustID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO [Cart] (prod_id, Cust_id) VALUES(@ProductID, @CustID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.Parameters.AddWithValue("@CustID", CustID);

                    cmd.ExecuteNonQuery();
                }
            }
        }






        public void DeleteProd(int CartID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM CART WHERE Cart_id = @CartID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CartID", CartID);

                    cmd.ExecuteNonQuery();
                }
            }
        }









        public int GetProdQuant(int CartID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT p.Quantity FROM Product as p JOIN Cart as c on c.prod_id=p.prod_id where cart_id=@CartID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CartID", CartID);

                    object result = cmd.ExecuteScalar();



                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {

                        return 0;
                    }
                }
            }
        }






        public List<Products> UpdateCartQuant(int CartID, int newQuantity, int custId)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();


                string query = "UPDATE Cart SET Quantity = @NewQuantity WHERE Cart_id = @CartID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    cmd.Parameters.AddWithValue("@CartID", CartID);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return DisplayCart(custId);


                }
            }
        }



        public void PlaceOrder(int CustID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                //string query = "INSERT INTO OrderDetails (Cust_id, Prods_Count, Total_price, Created_at) VALUES (@CustID, @Quantity, @TotalPrice, GetDate())";
                string query = "EXEC PlaceOrder @CustID = @Cust_id, @Quantity = @OrderQuantity , @TotalPrice = @OrderTotalPrice;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cust_id", CustID);
                    cmd.Parameters.AddWithValue("@OrderQuantity", GetQuantity(CustID));
                    cmd.Parameters.AddWithValue("@OrderTotalPrice", GetTotalPrice(CustID));


                    cmd.ExecuteNonQuery();
                }


            }
        }


        //public double GetTotalPrice(int CustID)
        //{
        //    using (SqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        string query = "SELECT SUM(p.New_price * c.Quantity) AS TotalPrice FROM Product as p INNER JOIN Cart as c ON c.Prod_id= p.Prod_id WHERE c.Cust_id = @CustID";
        //        using(SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@CustID",CustID);


        //            double TotalPrice = (double)cmd.ExecuteScalar();
        //            return TotalPrice;
        //        }
        //    }
        //}

        public double GetTotalPrice(int CustID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT SUM(p.New_price * c.Quantity) AS TotalPrice FROM Product as p INNER JOIN Cart as c ON c.Prod_id= p.Prod_id WHERE c.Cust_id = @CustID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustID", CustID);

                    // Handle nulls if there are no results (SUM might return NULL if no matching rows)
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        decimal TotalPrice = (decimal)result;
                        return (double)TotalPrice;  // Convert to double here
                    }
                    else
                    {
                        return 0.0;  // Return 0 if no result (i.e., no items in the cart)
                    }
                }
            }
        }



        public int GetQuantity(int CustID)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(Prod_id) AS OrderQuant FROM Cart WHERE Cust_id=@CustID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustID", CustID);


                    int OrderQuant = (int)cmd.ExecuteScalar();
                    return OrderQuant;

                }
            }
        }




        /*******************************Orders History*******************************************/
        public List<Orders> DisplayOrdersHistory(int CustID)
        {
            List<Orders> OrdersHistory = new List<Orders>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // The @ sign allows the string to be written as-is, without needing to escape special characters like backslashes.
                string query = @" SELECT 
							Order_id,
                            Cust_id,
                            Prods_Count,
                            Total_price,
                            Created_at,
                            Delivery_status
                       FROM OrderDetails
                       WHERE Cust_id=@CustID
                       ";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustID", CustID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        Orders order = new Orders()
                        {
                            OrderID = reader.GetInt32(reader.GetOrdinal("Order_id")),

                            CustID = reader.GetInt32(reader.GetOrdinal("Cust_id")),

                            ProdsCount = reader.GetInt32(reader.GetOrdinal("Prods_count")),

                            TotalPrice = reader.GetDecimal(reader.GetOrdinal("Total_price")),

                            OrderStatus = reader.GetBoolean(reader.GetOrdinal("Delivery_status")),

                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("Created_at"))
                        };

                        OrdersHistory.Add(order);
                    }
                }
            }
            return OrdersHistory;
        }





        public List<Products> DisplayOrderProducts(int OrderID)
        {
            List<Products> OrderProducts = new List<Products>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // The @ sign allows the string to be written as-is, without needing to escape special characters like backslashes.
                string query = @" SELECT 
							o.Prod_id, 
                            p.[Name] AS ProdName,
                            p.Size_id,
							p.Old_price, 
							p.Discount, 
							p.New_price, 
                            p.Available_f, 
                            p.Is_Active,
							p.Col_id,
                            o.Prod_quant,
                            o.Prod_price
                       FROM Order_Products o
                       JOIN Product p ON p.Prod_id = o.Prod_id
					   WHERE Order_id=@OrderID
                       ";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        Products product = new Products()
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("Prod_id")),

                            ProdName = reader.IsDBNull(reader.GetOrdinal("ProdName")) ? default : reader.GetString(reader.GetOrdinal("ProdName")),

                            Color = reader.GetString(reader.GetOrdinal("Col_id")),

                            OldPrice = reader.GetDecimal(reader.GetOrdinal("Old_price")),

                            Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? default : reader.GetDecimal(reader.GetOrdinal("Discount")),

                            NewPrice = reader.IsDBNull(reader.GetOrdinal("New_price")) ? default : reader.GetDecimal(reader.GetOrdinal("New_price")),

                            Available = reader.GetBoolean(reader.GetOrdinal("Available_f")),

                            IsActive = reader.GetBoolean(reader.GetOrdinal("Is_Active")),

                            OrderProductsObj = new OrderProducts
                            {
                                ProdQuant = reader.IsDBNull(reader.GetOrdinal("Prod_quant")) ? default : reader.GetInt32(reader.GetOrdinal("Prod_quant")),
                                ProdPrice = reader.GetDecimal(reader.GetOrdinal("Prod_price"))
                            }

                        };

                        OrderProducts.Add(product);
                    }


                }
            }
            return OrderProducts;
        }


        public List<Orders> GetPriceNQuant(int OrderID)
        {
            List<Orders> info = new List<Orders>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Total_price," +
                               "Prods_count," +
                               "Created_at " +
                               "FROM OrderDetails " +
                               "WHERE Order_id=@OrderID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Orders order = new Orders()
                        {
                            ProdsCount = reader.GetInt32(reader.GetOrdinal("Prods_count")),

                            TotalPrice = reader.GetDecimal(reader.GetOrdinal("Total_price")),

                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("Created_at"))

                        };

                        info.Add(order);
                    }
                }
            }
            return info;
        }



        



    }
}