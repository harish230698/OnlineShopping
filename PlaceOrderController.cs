using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Controllers
{
    public class PlaceOrderController : Controller
    {
        //List<LaptopModel> lstlaptopmodel = new List<LaptopModel>();
        private readonly LaptopDBContext _context;
        public PlaceOrderController(LaptopDBContext context)
        {
            _context = context;
        }
        public ActionResult PlaceOrder(int id, string val)
        {
            List<LaptopModel> lstOlddata = null;
            if (val == "Add")
            {
                LaptopModel model = new LaptopModel();

                var laptop = _context.Laptops.Where(s => s.SNo == id).ToList();
                if (laptop.Count > 0)
                    model = laptop[0];

                lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                    lstOlddata = new List<LaptopModel>();

                if (laptop.Count > 0)
                    lstOlddata.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);
                // return View(lstOlddata);
            }
            else if (val == "Remove")
            {
                LaptopModel model = new LaptopModel();
                lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata.Count > 0)
                {
                    var lapmodellst = lstOlddata.Where(item => item.SNo == id).ToList();
                    if (lapmodellst.Count > 0)
                    {
                        LaptopModel lapmodel = lapmodellst[0];
                        lstOlddata.Remove(lapmodel);
                    }
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


            }
            else
            {
                lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                {
                    lstOlddata = new List<LaptopModel>();
                }                

            }
            return View(lstOlddata);
        }

            public ActionResult ProceedToBuy(int id)
            {
                string user = HttpContext.Session.GetString("LoginUser");
                if (string.IsNullOrEmpty(user))
                {
                    TempData["ItemID"] = id;
                    return RedirectToAction("Login", "AddToCart");
                }
                else
                {
                    LaptopModel model = new LaptopModel();

                    var laptop = _context.Laptops.Where(s => s.SNo == id).ToList();
                    if (laptop.Count > 0)
                        model = laptop[0];

                    List<LaptopModel> lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                    if (lstOlddata == null)
                        lstOlddata = new List<LaptopModel>();

                    if (laptop.Count > 0)
                        lstOlddata.Add(model);

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


                    return RedirectToAction("Address","Address");
                }
            }

        }


        public static class SessionHelper
        {
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
    }
