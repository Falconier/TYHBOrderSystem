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
												var orders = DB.Orders.Where(o => o.PickUp_Due_Date.Equals(DateFormat));
												return View(orders);

								}
								public ActionResult WeeklyReport()
								{

												DateTime currentDate = DateTime.Now;
												string[] Dates = new string[7];
												for (int i = 0; i < 7; i++)
												{
																Dates[i] = currentDate.AddDays(i).ToString("MM/dd/yyyy");
												}

												//string WeekFormat = currentDate.AddDays(7).ToString("MM/dd/yyyy");
												//Should I return the days as a array then display orders based on date?
												//DB.Orders.Where(o => o.PickUp_Due_Date.ToString().Contains(WeekFormat));
												//var orders = DB.Orders.Where(o => o.PickUp_Due_Date.Contains(WeekFormat));

												var orders = DB.Orders.OrderByDescending(o => o.PickUp_Due_Date).ThenByDescending(o => o.CUSTOMER.Customer_Last_Name).Take(250); ;
												List<Order> ords = new List<Order>();
												foreach (var item in orders)
												{
																foreach (var day in Dates)
																{
																				if (item.PickUp_Due_Date.Equals(day))
																				{
																								ords.Add(item);
																				}
																}
												}

												ViewBag.Orders = ords.ToList();

												return View(ords);
								}
								public ActionResult OldOrderData(string searchString, string searching)
								{

												var orders = DB.Orders.Include(o => o.CUSTOMER).Include(o => o.EMPLOYEE).Include(o => o.INGREDIENT).Include(o => o.ORDER_SIZES);
												if (!String.IsNullOrEmpty(searchString))
												{
																if (searching == "1"){
																				orders = DB.Orders.Where(o => o.CUSTOMER.Customer_First_Name.Contains(searchString));
																}
																else if (searching == "2"){
																				orders = DB.Orders.Where(o => o.CUSTOMER.Customer_Last_Name.Contains(searchString));
																}
																else if (searching == "3"){
																				orders = DB.Orders.Where(o => o.Order_Date.Equals(searchString));
																}
																else if (searching == "4"){
																				orders = DB.Orders.Where(o => o.PickUp_Due_Date.Equals(searchString));
																}
													//		else if (searching == "5"){
													//							orders = DB.Orders.Where(o => o.ORDER_ID.Equals(searchString));
													//			}
													//			else if (searching == "6")
													//			{
													//							orders = DB.Orders.Where(o => o.Employee_ID.Equals(searchString));
													//			}
																else if (searching == "7")
																{
																				orders = DB.Orders.Where(o => o.EMPLOYEE.Emp_Last_Name.Equals(searchString));
																}
																else if (searching == "8")
																{
																				orders = DB.Orders.Where(o => o.EMPLOYEE.Emp_First_Name.Equals(searchString));
																}
																else if (searching == "9")
																{
																				orders = DB.Orders.Where(o => o.PRODUCT.Product_Flavor.Equals(searchString));
																}

												}
												return View(orders);
								}


								//Hopefully the code below works as well as it does with my test sheet    
								//  public ActionResult Index(string searchString)
								//  {
								//      var orders = DB.Orders.Include(o => o.CUSTOMER).Include(o => o.EMPLOYEE).Include(o => o.INGREDIENT).Include(o => o.ORDER_SIZES);
								//      if (!String.IsNullOrEmpty(searchString))
								//      {
								//          orders = DB.Orders.Where(o => o.Equals(searchString));
								//      }
								//      return View(orders.ToList());
								//  }


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

								[HttpPost]
								public string Index(string searchString, bool notUsed)
								{
												return "From [HttpPost]Index: filter on " + searchString;
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
