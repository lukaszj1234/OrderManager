using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManager.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int UserName { get; set; }
        public int BuildingName { get; set; }
        public string ExpectedDeliveryTime { get; set; }
        public bool InProgress { get; set; }
        public bool Ended { get; set; }
        public string AdminComment { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
