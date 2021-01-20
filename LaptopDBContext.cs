using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace OnlineShopping.Models
{
    public class LaptopDBContext :DbContext
    {
        public LaptopDBContext()
        {
        }

        public LaptopDBContext(DbContextOptions<LaptopDBContext> options) 
            :base(options)
        {

        }
        public DbSet<LaptopModel> Laptops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<LaptopModel>().HasData(
                new LaptopModel { SNo = 1, ImagePath ="/HP14.jpg", ModelName = "HP 14 Ultra Thin & Light", Specification = "10th Gen i3-1005G1/8GB/256GB SSD", color = "Black", Price = 40000.00 },
                new LaptopModel { SNo = 2, ImagePath = "/Lenovo.jpg", ModelName = "Lenovo IdeaPad S540",Specification= "8GB/1TB HDD + 256GB SSD",color= "Mineral Grey",Price=53000.00 },
                new LaptopModel { SNo = 3, ImagePath = "/Dell.jpg", ModelName = "Dell Vostro 3491", Specification = "10th Gen i3-1005G1/4GB/1TB HDD + 256GB SSD", color = "Black", Price = 70000.00 },
                new LaptopModel { SNo = 4, ImagePath = "/Apple.jpg", ModelName = "Apple MacBook Air", Specification = "13-inch, 8GB RAM, 128GB Storage", color = "Silver", Price = 56000.00 },
                new LaptopModel { SNo = 5, ImagePath = "/Mi.jpg", ModelName = "Mi Notebook 14", Specification = "8GB/256GB SSD", color = "Black", Price = 47000.00 },
                new LaptopModel { SNo = 6, ImagePath = "/Acer.jpg", ModelName = "Acer Aspire 3", Specification = "8GB/512GB SSD", color = "Silver", Price = 68000.00 }
                );
        }
    }
}
