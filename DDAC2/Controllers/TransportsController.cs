using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDAC2.Models;

namespace DDAC2.Controllers
{
    public class TransportsController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Transports
        public ActionResult Index()
        {
            var transports = db.Transports.Include(t => t.Container).Include(t => t.Ship).Include(t => t.Shipyard).Include(t => t.Shipyard2);
            return View(transports.ToList());
        }

        // GET: Transports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transports/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            ViewBag.ArrivalShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName");
            ViewBag.DepartureShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName");
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "TransportID,ShipID,ContainerID,ArrivalTime,DepartureTime,Price,ArrivalShipyardID,DepartureShipyardID")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Transports.Add(transport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", transport.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", transport.ShipID);
            ViewBag.ArrivalShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName", transport.ArrivalShipyardID);
            ViewBag.DepartureShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName", transport.DepartureShipyardID);
            return View(transport);
        }

        // GET: Transports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", transport.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", transport.ShipID);
            ViewBag.ArrivalShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName", transport.ArrivalShipyardID);
            ViewBag.DepartureShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName", transport.DepartureShipyardID);
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "TransportID,ShipID,ContainerID,ArrivalTime,DepartureTime,Price,ArrivalShipyardID,DepartureShipyardID")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerName", transport.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", transport.ShipID);
            ViewBag.ArrivalShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName", transport.ArrivalShipyardID);
            ViewBag.DepartureShipyardID = new SelectList(db.ShipYards, "ShipYardID", "ShipYardName", transport.DepartureShipyardID);
            return View(transport);
        }

        // GET: Transports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = db.Transports.Find(id);
            db.Transports.Remove(transport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
