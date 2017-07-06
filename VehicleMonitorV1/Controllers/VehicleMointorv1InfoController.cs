using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMonitorV1.Controllers
{
    public class VehicleMointorv1InfoController : Controller
    {
        // GET: VehicleMointorv1Info
        /*
        public ActionResult Index()
        {
            return View();
        }*/
        public String Index()
        {
            return "I am doing this project as a web server to display vehicle position data in real time";
        }
    }
}