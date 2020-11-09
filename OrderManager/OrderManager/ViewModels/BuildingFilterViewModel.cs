using OrderManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManager.ViewModels
{
    public class BuildingFilterViewModel
    {
        public Building Building { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
