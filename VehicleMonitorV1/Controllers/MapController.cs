﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMonitorV1.Controllers
{
    public class MapController : Controller
    {
        // GET: BaseMap
        public ActionResult BaseMap()
        {
            ViewBag.VLat = -27.4698 + (new Random().NextDouble());
            ViewBag.VLon = 153.0251 + (new Random().NextDouble());
            return View();
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
