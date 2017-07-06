using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMonitorV1.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        
        public ActionResult Index()
        {
            //ViewBag.Message = "The Vehicle 
            return View();
        }
        public ActionResult Position()
        {
            string plate = "SUBIEWRX";
            ViewBag.Message = $"The Vehicle {plate}";
            ViewBag.VLat = -27;
            ViewBag.VLon = 153;
            return View();
        }
        /*
        public string Index(string content, int ID = 1)
        {
            return HttpUtility.HtmlEncode($"TEST: show {content}");
        }*/
    }
}