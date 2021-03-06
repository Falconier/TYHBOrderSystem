﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TYHBOrderSystem.Models;
using TYHBOrderSystem.Models.View_Models;

namespace TYHBOrderSystem.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

								// GET: Customers
								[Authorize(Roles = "Admin, Baker")]
								public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

								// GET: Customers/Details/5
								[Authorize(Roles = "Admin, Baker")]
								public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

								// GET: Customers/Create
								[Authorize(Roles = "Admin, Baker")]
								public ActionResult CreateForOrder()
        {
            

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForOrder(CustomerViewModels tempCustomer,[Bind(Include = "Customer_ID,Customer_First_Name,Customer_Last_Name,Contact_Number,Alternate_Contact_Number,Allergy_Desctiption,Email_Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Customer_First_Name = tempCustomer.FirstName;
                customer.Customer_Last_Name = tempCustomer.LastName;
                customer.Contact_Number = tempCustomer.PrimarymNum;
                customer.Alternate_Contact_Number = tempCustomer.AlternativeNum;
                customer.Email_Address = tempCustomer.EmailAddress;
                customer.Allergy_Desctiption = tempCustomer.AllergyDesc;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Create","Orders");
            }
                
            return View(tempCustomer);
        }

								#region For later use
								//// GET: Customers/Create
								//public ActionResult Create()
								//{
								//    return View();
								//}

								//// POST: Customers/Create
								//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
								//// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
								//[HttpPost]
								//[ValidateAntiForgeryToken]
								//public ActionResult Create([Bind(Include = "Customer_ID,Customer_First_Name,Customer_Last_Name,Contact_Number,Alternate_Contact_Number,Allergy_Desctiption,Email_Address")] Customer customer)
								//{
								//    if (ModelState.IsValid)
								//    {
								//        db.Customers.Add(customer);
								//        db.SaveChanges();
								//        return RedirectToAction("Index");
								//    }

								//    return View(customer);
								//}
								#endregion

								// GET: Customers/Edit/5
								[Authorize(Roles = "Admin, Baker")]
								public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_ID,Customer_First_Name,Customer_Last_Name,Contact_Number,Alternate_Contact_Number,Allergy_Desctiption,Email_Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

								// GET: Customers/Delete/5
								[Authorize(Roles = "Admin")]
								public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

								// POST: Customers/Delete/5
								[Authorize(Roles = "Admin")]
								[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
