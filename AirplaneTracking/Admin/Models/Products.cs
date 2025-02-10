using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneTracking.Admin.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProdName { get; set; }   
        public Categories CategoriesObj { get; set; }
        public Size SizeObj { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public int Quantity { get; set; }
        public decimal OldPrice {get; set; }
        public decimal Discount { get; set; }
        public decimal NewPrice { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public DateTime CreatedAt { get; set; }

        // pytting ? after "DateTime" to allow null values
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }

        public OrderProducts OrderProdObj { get; set; } 

    }


    public class Categories
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
    }


    public class Size
    {
        public int SizeID { get; set; }
        public string SizeName { get; set; }
    }

    public class OrderProducts
    {
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NewPrice { get; set; }
        public int ProdQuant { get; set; }
        public decimal ProdPrice { get; set; }
        
    }

    
}