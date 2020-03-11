using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TYHBOrderSystem.Models;

namespace TYHBOrderSystem.Views.Edit
{
    public class ProductsController : Controller
    {
        private BakeryModels db = new BakeryModels();

        // GET: Products
								//[Authorize]
        public ActionResult Index()
        {
            return View(db.PRODUCTS.ToList());
        }

        // GET: Products/Details/5
								//[Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.PRODUCTS.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
								//[Authorize(Roles = "Admin, Owner")]
        public ActionResult Create()
        {
												IEnumerable<String> items = db.PRODUCTS.Select(product => product.Product_Type).Distinct().ToList();

												//TODO: set items to type SelectListItem

												//IEnumerable<SelectListItem> itemList = db.PRODUCTS.Select(p => p.Product_Type).Distinct().ToList();
												//var itemList = items.Select(p => new SelectListItem { Text = p, Value = p }).ToList();
												List<SelectListItem> itemList = new List<SelectListItem>();
												foreach(var i in items)
												{
																itemList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
												}
												//ViewBag.ProductType = items;
												ViewBag.Product_Type = new SelectList(itemList,"Product_Type");
												//ViewBag.Product
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
								//[Authorize(Roles = "Admin, Owner")]
								public ActionResult Create([Bind(Include = "Product_ID,Product_Type,Product_Flavor,Product_Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTS.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

								// GET: Products/Edit/5
								//[Authorize(Roles = "Admin, Owner")]
								public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.PRODUCTS.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
								//[Authorize(Roles = "Admin, Owner")]
								public ActionResult Edit([Bind(Include = "Product_ID,Product_Type,Product_Flavor,Product_Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

								// GET: Products/Delete/5
								//[Authorize(Roles = "Admin, Owner")]
								public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.PRODUCTS.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
								//[Authorize(Roles = "Admin, Owner")]
								public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(product);
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
