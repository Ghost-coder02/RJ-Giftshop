using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AirplaneTracking.Admin.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public Customer CustomerObj { get; set; }
        public int ProdsCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }



    public class Customer
    {
        public int CustID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Username { get; set; }
        public bool Gender { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}