using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public Building Building { get; set; }
        public string ExpectedDeliveryTime { get; set; }
        public bool InProgress { get; set; }
        public bool Ended { get; set; }
        public string AdminComment { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
