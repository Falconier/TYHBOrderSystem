using System;
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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.CUSTOMER).Include(o => o.EMPLOYEE).Include(o => o.INGREDIENT).Include(o => o.ORDER_SIZES);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name");
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name");
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type");
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID");
            ViewBag.Category = new SelectList(db.ProductTypes, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDER_ID,Customer_ID,Order_Date,Order_Time,PickUp_Due_Date,PickUp_Time,Product_Type_ID,Ingredient_Substitution,Decoration_Comments,Additional_Comments,Employee_ID,Order_Size_ID,Finishing_ID,Ingredient_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name", order.Employee_ID);
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type", order.Ingredient_ID);
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID", order.Order_Size_ID);
            ViewBag.Categories = new SelectList(db.ProductTypes, "ID", "Name" order.)
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name", order.Employee_ID);
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type", order.Ingredient_ID);
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID", order.Order_Size_ID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDER_ID,Customer_ID,Order_Date,Order_Time,PickUp_Due_Date,PickUp_Time,Product_Type_ID,Ingredient_Substitution,Decoration_Comments,Additional_Comments,Employee_ID,Order_Size_ID,Finishing_ID,Ingredient_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name", order.Employee_ID);
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type", order.Ingredient_ID);
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID", order.Order_Size_ID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
