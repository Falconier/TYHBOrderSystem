using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

            int switchOrderSizeValue = order.PRODUCT.TypeId;
            switch (switchOrderSizeValue)
            {
                case 2:
                    int tempOrderSize = order.ORDER_SIZES.Order_Size;
                    string orderSizeforView = tempOrderSize.ToString();
                    ViewBag.OrderSizeforView = $"{orderSizeforView} inches";
                    break;

                case 3:
                    tempOrderSize = order.ORDER_SIZES.Order_Size;
                    orderSizeforView = tempOrderSize.ToString();
                    ViewBag.OrderSizeforView = $"{orderSizeforView} count";
                    break;

                case 5:
                    tempOrderSize = order.ORDER_SIZES.Order_Size;
                    orderSizeforView = tempOrderSize.ToString();
                    ViewBag.OrderSizeforView = $"{orderSizeforView} count";
                    break;

                case 7:
                    tempOrderSize = order.ORDER_SIZES.Order_Size;
                    orderSizeforView = tempOrderSize.ToString();
                    ViewBag.OrderSizeforView = $"{orderSizeforView} inches";
                    break;

                case 10:
                    string sheetCakeString = "18 x 12";
                    ViewBag.OrderSizeforView = sheetCakeString.ToString();
                    break;

                case 11:
                    tempOrderSize = order.ORDER_SIZES.Order_Size;
                    orderSizeforView = tempOrderSize.ToString();
                    ViewBag.OrderSizeforView = $"{orderSizeforView} count";
                    break;

                case 12:
                    tempOrderSize = order.ORDER_SIZES.Order_Size;
                    orderSizeforView = tempOrderSize.ToString();
                    ViewBag.OrderSizeforView = $"{orderSizeforView} count";
                    break;

                default:
                    ViewBag.OrderSizeforView = "";
                    break;

            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create(string searching, string itemchoice)
        {
            
            //Product Categories for View
            ViewBag.ProductCategoryList = db.ProductTypes.ToList();
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name");
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name");
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type");

            //Order Date/Order Time View
            DateTime currentDate = DateTime.Now;
            string orderDateFormat = currentDate.ToString("MM/dd/yyyy");
            string timeDateFormat = currentDate.ToString("h:mm tt");
            ViewBag.CurrentDate = orderDateFormat;
            ViewBag.CurrentTime = timeDateFormat;

            //Order_Size_ID toList for data mutation for View Display
            var orderSizeList = db.OrderSizes.ToList();

            //Select List Items for Order Sizes with Layers
            IEnumerable<SelectListItem> selectListQueryCakes = from o in orderSizeList
                                                          where o.Number_Of_Layers != 0 && o.Product_Type_ID == itemchoice
                                                          select new SelectListItem
                                                          {
                                                              Value = o.Order_Size_ID.ToString(),
                                                              Text = o.Order_Size.ToString() + " inches" + " - " + o.Number_Of_Layers.ToString() + " layers"
                                                          };

            IEnumerable<SelectListItem> selectListQueryPie = from o in orderSizeList
                                                             where o.Number_Of_Layers == 0 && o.Product_Type_ID == itemchoice
                                                             select new SelectListItem
                                                             {
                                                                 Value = o.Order_Size_ID.ToString(),
                                                                 Text = o.Order_Size.ToString() + " inches"
                                                             };

            //SelectListItem for Order Sizes without Layers
            IEnumerable < SelectListItem > selectListQueryDefault = from o in orderSizeList
                                                                    where o.Number_Of_Layers == 0 && o.Product_Type_ID == itemchoice
                                                                    select new SelectListItem
                                                                    {
                                                                        Value = o.Order_Size_ID.ToString(),
                                                                        Text = o.Order_Size.ToString() + " count"

                                                                    };

            //Default Set for 'View' on load
            ViewBag.Order_Size_ID = new SelectList(selectListQueryDefault, "Value", "Text");

            //Ingredients Sub for View
            ViewBag.IngredientSub = db.Ingredients.ToList();

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

                if (itemchoice == "1")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model=>model.TypeId.Equals(tempChoice));
                    return View();
                }
                else if(itemchoice == "2")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryCakes, "Value", "Text");
                    return View();
                }
                else if(itemchoice == "3")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryDefault, "Value", "Text");
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
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryDefault, "Value", "Text");
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
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryPie, "Value", "Text");
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
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryCakes, "Value", "Text");
                    return View();
                }
                else if(itemchoice == "11")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryDefault, "Value", "Text");
                    return View();
                }
                else if(itemchoice == "12")
                {
                    int tempChoice = int.Parse(itemchoice);
                    ViewBag.DietResitrictionSearch = db.Products.Where(model => model.RestrictionId.Equals(_search)).Where(model => model.TypeId.Equals(tempChoice));
                    ViewBag.Order_Size_ID = new SelectList(selectListQueryDefault, "Value", "Text"); 
                    return View();
                }

            }

            return View();
        }


        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //Removed Finishing_ID, from BIND
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormCollection form,[Bind(Include = "ORDER_ID,Customer_ID,Order_Date,Order_Time,PickUp_Due_Date,PickUp_Time,Ingredient_Substitution,Decoration_Comments,Additional_Comments,Employee_ID, Ingredient_ID, Order_Size_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                //Get Product ID: Create Product Object with chosen product ID, set to 'ORDER'
                string chosenID = form["chosenID"];
                int tempChosenID = int.Parse(chosenID);
                Product productChoice = db.Products.Find(tempChosenID);
                order.PRODUCT = productChoice;
                if (form["substitution"] != null)
                {
                    //Get Ingredient Substitution: Ingredient_ID(INT)
                    string chosenSubIngredient = form["substitution"];
                    int tempChosenSubIngredient = int.Parse(chosenSubIngredient);
                    order.Ingredient_ID = tempChosenSubIngredient;

                    //Get Ingredient_Substitution (String)
                    var chosenIngredientQuery = from i in db.Ingredients
                                                where i.Ingredient_ID == tempChosenSubIngredient
                                                select i.Ingredient_Name;
                    string chosenIngredientValue = chosenIngredientQuery.FirstOrDefault().ToString();
                    order.Ingredient_Substitution = chosenIngredientValue;
                }
                else
                {
                    order.Ingredient_ID = null;
                }
                

                //Order Date
                DateTime currentDate = DateTime.Now;
                string orderDate = currentDate.ToString("MM/dd/yyyy");
                order.Order_Date = orderDate;

                DateTimeOffset currentTime = DateTimeOffset.Now;
                order.Order_Time = currentTime;

               
                db.Orders.Add(order);
                db.SaveChanges();

                try
                {
                    EmailService ems = new EmailService();
                    IdentityMessage msg = new IdentityMessage();
                    Customer cust = new Customer();
				    cust = db.Customers.Find(order.Customer_ID);

                    var callbackUrl = Url.Action("Details", "Orders", new { id = order.ORDER_ID },
                                                        protocol: Request.Url.Scheme);

                    msg.Body = "Thanks for placing an order with To Your Health Bakery!\n" +
                                "Order Details:\n" +
                                "<a href=\"" + callbackUrl + "\">Order Details</a>";
                    msg.Destination = cust.Email_Address;
                    msg.Subject = "Order Confirmation: To Your Health Bakery";

                    await ems.SendMailAsync(msg);
                }
                catch(Exception)
                {
                    await Task.FromResult(0);
                }

                return RedirectToAction("Details", new { id = order.ORDER_ID });
            }



            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_First_Name", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "Employee_ID", "Emp_First_Name", order.Employee_ID);
            ViewBag.Ingredient_ID = new SelectList(db.Ingredients, "Ingredient_ID", "Ingredient_Type", order.Ingredient_ID);
            ViewBag.Order_Size_ID = new SelectList(db.OrderSizes, "Order_Size_ID", "Product_Type_ID", order.Order_Size_ID);

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
