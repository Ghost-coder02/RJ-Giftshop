using System.Collections.Generic;

namespace AirplaneTracking.Admin.Models
{
    public class CategoriesModel    
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Category> Data { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}