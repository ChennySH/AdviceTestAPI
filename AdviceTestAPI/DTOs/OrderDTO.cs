using System;
using System.Collections.Generic;
namespace AdviceTestAPI.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreEmail { get; set; }
        public bool IsEarly { get; set; }
        public bool IsLate { get; set; }
        public TimeSpan TimeDifference { get; set; }
    }
}
