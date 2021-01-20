using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopDBContext _context;
        public LaptopController(LaptopDBContext context)
        {
            _context = context;
        }
        // GET: LaptopController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Laptops.ToListAsync());
        }

        // GET: LaptopController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var laptop = await _context.Laptops.FirstOrDefaultAsync(x => x.SNo == id);
            if(laptop==null)
            {
                return NotFound();
            }
            return View(laptop);
        }

       
    }
}
