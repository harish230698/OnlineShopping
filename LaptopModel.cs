using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
    [Table("tbllaptop")]
    public class LaptopModel
    {
        [Key]
        public int SNo { get; set; }

        public string ImagePath { get; set; }
        public string ModelName { get; set; }
        public string Specification { get; set; }
        public string color { get; set; }
        
        public double Price { get; set; }

      
    }
}
