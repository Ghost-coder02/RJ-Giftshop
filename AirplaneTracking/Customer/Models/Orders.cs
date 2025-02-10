using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneTracking.Customer.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustID { get; set; }
        public int ProdsCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}