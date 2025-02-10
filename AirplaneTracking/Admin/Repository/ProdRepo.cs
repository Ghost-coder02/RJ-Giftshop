using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using AirplaneTracking.Admin.Models;

namespace AirplaneTracking.Admin.Repository
{
    public class ProdRepo
    {

        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;

        }


        

        public DataTable GetSizes()  // method that returns a DataTable containing the results of the query.
        {

            DataTable dt = new DataTable(); // creates a new DataTable object to hold the data that will be retrieved from the database.


            using (SqlConnection conn = GetConnection())
            {
                conn.Open(); //Opens the database connection
                string query = "SELECT * from [Size]";



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


        public List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // The @ sign allows the string to be written as-is, without needing to escape special characters like backslashes.
                string query = @"SELECT 
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
                        //string name = "Ahmad";

                      

                        Products product = new Products()
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("Prod_id")),
                            ProdName = reader.IsDBNull(reader.GetOrdinal("ProdName")) ? default : reader.GetString(reader.GetOrdinal("ProdName")),

                            CategoriesObj = new Categories
                            {
                                CatID = reader.GetInt32(reader.GetOrdinal("Cat_id")),
                                //CatName = name,
                                CatName = reader.GetString(reader.GetOrdinal("CategoryName")),
                            },

                            SizeObj = new Models.Size
                            {
                                SizeID = reader.GetInt32(reader.GetOrdinal("Size_id")),
                                //SizeName = name,
                                SizeName = reader.GetString(reader.GetOrdinal("SizeName")),
                            },

                            Color = reader.GetString(reader.GetOrdinal("Col_id")),

                            Material = reader.IsDBNull(reader.GetOrdinal("Material")) ? default : reader.GetString(reader.GetOrdinal("Material")),

                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),

                            OldPrice = reader.GetDecimal(reader.GetOrdinal("Old_price")),

                            Discount = reader.IsDBNull(reader.GetOrdinal("Discount")) ? default : reader.GetDecimal(reader.GetOrdinal("Discount")),

                            NewPrice = reader.IsDBNull(reader.GetOrdinal("New_price")) ? default : reader.GetDecimal(reader.GetOrdinal("New_price")),

                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? default : reader.GetString(reader.GetOrdinal("Description")),

                            Available = reader.GetBoolean(reader.GetOrdinal("Available_f")),

                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("Created_at")),

                            UpdatedAt = reader.IsDBNull(reader.GetOrdinal("Updated_at")) ? default : reader.GetDateTime(reader.GetOrdinal("Updated_at")),

                            DeletedAt = reader.IsDBNull(reader.GetOrdinal("Deleted_at")) ? default : reader.GetDateTime(reader.GetOrdinal("Deleted_at")),

                            IsActive = reader.GetBoolean(reader.GetOrdinal("Is_Active"))
                        };

                        products.Add(product);
                    }


                }
            }
            return products;
        }




        public void UpdateProd(int ProdID, string ProdName, int Cat, int Size, string Color, string Material, int Quantity, decimal OldPrice, decimal Discount, string Description, bool Available)
        {

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE Product SET Name = @ProdName, Cat_id = @CatID, Size_id = @SizeID, Col_id = @ColorID, Material = @ProdMat, Quantity = @ProdQuant, Old_price = @ProdOld, Discount = @ProdDisc," +
                        " Description = @ProdDesc, Available_f = @ProdAva, Updated_at=GetDate()" +
                        " WHERE Prod_id = @ProdID;";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@ProdName", ProdName);
                    cmd.Parameters.AddWithValue("@ProdID", ProdID);
                    cmd.Parameters.AddWithValue("@CatID", Cat);
                    cmd.Parameters.AddWithValue("@SizeID", Size);
                    cmd.Parameters.AddWithValue("@ColorID", Color);
                    cmd.Parameters.AddWithValue("@ProdMat", Material);
                    cmd.Parameters.AddWithValue("@ProdQuant", Quantity);
                    cmd.Parameters.AddWithValue("@ProdOld", OldPrice);
                    cmd.Parameters.AddWithValue("@ProdDisc", Discount);
                    cmd.Parameters.AddWithValue("@ProdDesc", Description);
                    cmd.Parameters.AddWithValue("@ProdAva", Available);


                    cmd.ExecuteNonQuery();
                }
            }
        }





        public void AddProd( string ProdName, int Cat, int Size, string Color, string Material, int Quantity, decimal OldPrice, decimal Discount, string Description, bool Available)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO [Product] (Name, Cat_id, Size_id, Col_id, Material, Quantity, Old_price, Discount, Description, Available_f, Created_at) " +
                        " VALUES (@ProdName, @CatID, @SizeID, @ColorID, @ProdMat, @ProdQuant, @ProdOld, @ProdDisc, @ProdDesc, @ProdAva, GETDATE());";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdName", ProdName);
                    cmd.Parameters.AddWithValue("@CatID", Cat);
                    cmd.Parameters.AddWithValue("@SizeID", Size);
                    cmd.Parameters.AddWithValue("@ColorID", Color);
                    cmd.Parameters.AddWithValue("@ProdMat", Material);
                    cmd.Parameters.AddWithValue("@ProdQuant", Quantity);
                    cmd.Parameters.AddWithValue("@ProdOld", OldPrice);
                    cmd.Parameters.AddWithValue("@ProdDisc", Discount);
                    cmd.Parameters.AddWithValue("@ProdDesc", Description);
                    cmd.Parameters.AddWithValue("@ProdAva", Available);

                    cmd.ExecuteNonQuery();
                }
            }

        }



        public void Disable(int Prod_id)
        {
            using (SqlConnection conn = GetConnection()){
                conn.Open();
                string query = "UPDATE Product SET Is_Active= 0" +
                        " WHERE Prod_id = @ProdID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdID", Prod_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Enable(int Prod_id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE Product SET Is_Active= 1" +
                        " WHERE Prod_id = @ProdID;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdID", Prod_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

        // params is keyword that can be used to pass multipule arguments to the method WITH THE SAME TYPE
        // return true should be out of the loop 'cause the other way it will return true after checking one argument
        public bool Validate(params string[] fields)
        {
            for(int i=0; i< fields.Length; i++)
            {
                if (string.IsNullOrEmpty(fields[i]))
                {
                    return false;
                }
            
            }
            return true;
        }





    }
}









