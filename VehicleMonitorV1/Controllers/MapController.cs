using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleMonitorV1.Models;
using System.Net;


namespace VehicleMonitorV1.Controllers
{
    public class MapController : Controller
    {
        private List<Vehicle> VehicleList = new List<Vehicle>();
        // GET: Data
        public MapController()
        {
            VehicleList.Clear();
            VehicleList.Add(Vehicle.GetVehicleFromDB("502WRY"));
        }
        public ActionResult Position(int? id)
        {

            return Json(VehicleList.First(), JsonRequestBehavior.AllowGet);
        }
        // GET: BaseMap
        public ActionResult BaseMap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //VehicleList.Clear();
            //VehicleList.Add(Vehicle.GetAVehicleFromDB());
            var aCar = VehicleList.Find(v => { return v.ID == id; });
            if (null == aCar)
            {
                return HttpNotFound();
            }
            //return View(aCar);
            return PartialView(aCar);
        }
        // GET: Map
        public ActionResult Index()
        {
            //RedirectToAction("BaseMap");
            return RedirectToAction("BaseMap");
        }

        // GET: Map/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Map/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Map/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Map/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Map/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Map/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Map/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
