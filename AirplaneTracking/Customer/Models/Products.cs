namespace AirplaneTracking.Customer.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProdName { get; set; }
        public Categories CategoriesObj { get; set; }
        public Size SizeObj { get; set; }
        public Cart CartObj { get; set; }
        public OrderProducts OrderProductsObj { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public int Quantity { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NewPrice { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public bool IsActive { get; set; }

    }


    public class Cart
    {
        public int CartID { get; set; }
        public int CartQuant { get; set; }
    }

    public class Categories
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
    }

    public class Size
    {
        public int SizeID { get; set; }
        public string SizeName { get; set; }
    }

    public class OrderProducts
    {
        public int ProdQuant { get; set; }
        public decimal ProdPrice { get; set; }
    }
}