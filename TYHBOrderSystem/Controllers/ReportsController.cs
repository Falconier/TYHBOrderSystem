﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TYHBOrderSystem.Models;

namespace TYHBOrderSystem.Controllers
{
    public class ReportsController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        // GET: Reports
        public ActionResult Index()
        {
            return View();
            
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = DB.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult DailyReport()
        {

            DateTime currentDate = DateTime.Now;
            string DateFormat = currentDate.ToString("MM/dd/yyyy");
            var orders = DB.Orders.Include(o => o.CUSTOMER).Include(o => o.EMPLOYEE).Include(o => o.INGREDIENT).Include(o => o.ORDER_SIZES);
            IEnumerable<SelectListItem> selectListDaily = from o in orders
                                                           where o.PickUp_Due_Date == DateFormat
                                                           select new SelectListItem
                                                           {
                                                               Value = o.PickUp_Due_Date.ToString(),
                                                               Text = o.PickUp_Due_Date.ToString()
                                                           };


            ViewBag.PickUp_Due_Date = new SelectList(selectListDaily, "Value" ,"Text");
            return View(orders.ToList());

        }
        public ActionResult WeeklyReport()
        {

            DateTime currentDate = DateTime.Now;
            string DateFormat = currentDate.ToString("MM/dd/yyyy");
            var orders = DB.Orders.Include(o => o.CUSTOMER).Include(o => o.EMPLOYEE).Include(o => o.INGREDIENT).Include(o => o.ORDER_SIZES);
            IEnumerable<SelectListItem> selectListWeekly = from o in orders
                                                           where o.PickUp_Due_Date == DateFormat
                                                           select new SelectListItem
                                                           {
                                                               Value = o.PickUp_Due_Date.ToString(),
                                                               Text = o.PickUp_Due_Date.ToString()
                                                           };


            ViewBag.PickUp_Due_Date = new SelectList(selectListWeekly, "Value", "Text");

            return View(orders.ToList());
        }
        public ActionResult OldOrderData()
        {

            var orders = DB.Orders.Include(o => o.CUSTOMER).Include(o => o.EMPLOYEE).Include(o => o.INGREDIENT).Include(o => o.ORDER_SIZES);
            return View(orders.ToList());
        }

        // POST: Reports/Create
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

        // GET: Reports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reports/Edit/5
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

        // GET: Reports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reports/Delete/5
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
