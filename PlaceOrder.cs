using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    
    public class PlaceOrder
    {
        public int SNo { get; set; }
        public string ImagePath { get; set; }
        public string ModelName { get; set; }
        public int Qty { get; set; }
        public string EmailId { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
