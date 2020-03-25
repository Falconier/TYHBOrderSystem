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
        public ActionResult Create(string searching, string itemchoice)
        {
           
           
            //Working on autopopulating order date and time
            DateTime currentDate = DateTime.Now;
            string orderDate = currentDate.ToString("MM/dd/yyyy");

            //Ingredient Substitution CheckList
            
            //Product Categories for View
            ViewBag.ProductCategoryList = db.ProductTypes.ToList();

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name");
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name");
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type");
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID");

            //Updated Product Catgories to ViewBag
            //ViewBag.ProductCategoryList = new SelectList(productCategory, "Id", "Name");

            //Filter for Radio Button and DropDownList
            ViewBag.DietResitrictionSearch = db.Products.ToList();

            if (searching is null)
            {
                ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(0));
                
                return View();
            }
            else
            {
                int _search = int.Parse(searching);

                if(itemchoice == "1")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model=>model.TypeId.Equals(tempChoice));
                    
                    return View();
                }
                else if(itemchoice == "2")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "3")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "4")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "5")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "6")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "7")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "8")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "9")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "10")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "11")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "12")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    return View();
                }

            }
            
            return View();
        }


        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Removed "Product_Type_ID" from Bind CW 3_17
        public ActionResult Create([Bind(Include = "ORDER_ID,Customer_ID,Order_Date,Order_Time,PickUp_Due_Date,PickUp_Time,Ingredient_Substitution,Decoration_Comments,Additional_Comments,Employee_ID,Order_Size_ID,Finishing_ID,Ingredient_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Order Date
            DateTime currentDate = DateTime.Now;
            string orderDate = currentDate.ToString("MM/dd/yyyy");
            order.Order_Date = orderDate;

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name", order.Employee_ID);
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type", order.Ingredient_ID);
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID", order.Order_Size_ID);
           
            ViewBag.DietResitrictionSearch = db.Products.ToList();


            //ViewBag.Categories = new SelectList(db.ProductTypes, "ID", "Name" order.PRODUCT.)

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
