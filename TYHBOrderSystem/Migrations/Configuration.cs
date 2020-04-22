namespace TYHBOrderSystem.Migrations
{
				using Microsoft.AspNet.Identity;
				using Microsoft.AspNet.Identity.EntityFramework;
				using System;
				using System.Data.Entity;
				using System.Data.Entity.Migrations;
				using System.Linq;
				using TYHBOrderSystem.Models;

				internal sealed class Configuration : DbMigrationsConfiguration<TYHBOrderSystem.Models.ApplicationDbContext>
				{
								public Configuration()
								{
												AutomaticMigrationsEnabled = true;
								}

								protected override void Seed(TYHBOrderSystem.Models.ApplicationDbContext context)
								{

												var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

												var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
												//if (!System.Diagnostics.Debugger.IsAttached)
												//    System.Diagnostics.Debugger.Launch();
												#region Role Seeds
												//Sets Administrator (Admin)
												if (!context.Roles.Any(r => r.Name == "Admin"))
												{
																roleManager.Create(new IdentityRole { Name = "Admin" });
												}

												if (!context.Users.Any(u => u.Email == "admin@email.com"))
												{
																userManager.Create(new ApplicationUser { UserName = "admin@email.com", Email = "admin@email.com", FirstName = "Testing", LastName = "Admin" }, "password");
												}

												var userId = userManager.FindByEmail("admin@email.com").Id;
												userManager.AddToRole(userId, "Admin");

												////Sets Owners (Owner)
												//if (!context.Roles.Any(r => r.Name == "Owner"))
												//{
												//				roleManager.Create(new IdentityRole { Name = "Owner" });
												//}

												//if (!context.Users.Any(u => u.Email == "Owner@email.com"))
												//{
												//				userManager.Create(new ApplicationUser { UserName = "owner@email.com", Email = "owner@email.com", FirstName = "Testing", LastName = "Owner" }, "password");
												//}

												//var userId2 = userManager.FindByEmail("Owner@email.com").Id;
												//userManager.AddToRole(userId, "Owner");

												//Sets Moderator (Mod)
												if (!context.Roles.Any(r => r.Name == "Baker"))
												{
																roleManager.Create(new IdentityRole { Name = "Baker" });
												}

												if (!context.Users.Any(u => u.Email == "baker@email.com"))
												{
																userManager.Create(new ApplicationUser { UserName = "baker@email.com", Email = "baker@email.com", FirstName = "Testing", LastName = "Baker" }, "password");
												}

												var userId3 = userManager.FindByEmail("baker@email.com").Id;
												userManager.AddToRole(userId2, "Baker");
												#endregion

												//Seed Test Customers and Test Employees
												#region Test Customer & Employee Seeds
												//Test Customers
												if (!context.Customers.Any(c => c.Customer_First_Name.Contains("Test")))
												{
																context.Customers.Add(new Customer
																{
																				Customer_ID = 1,
																				Customer_First_Name = "Test_Cus_One",
																				Customer_Last_Name = "Customer_One",
																				Contact_Number = "123-456-7890",
																				Email_Address = "testc1@null.com"
																});
																context.Customers.Add(new Customer
																{
																				Customer_ID = 2,
																				Customer_First_Name = "Test_Cus_Two",
																				Customer_Last_Name = "Customer_Two",
																				Contact_Number = "908-765-4321",
																				Email_Address = "testc2@null.com"
																});
												}

												//Test Employees
												if (!context.Employees.Any(e => e.Emp_First_Name.Contains("Test")))
												{
																context.Employees.Add(new Employees
																{
																				Employee_ID = 1,
																				Emp_First_Name = "Test_Emp_One",
																				Emp_Last_Name = "Employee_One",
																				Emp_Initials = "TE1"
																});
																context.Employees.Add(new Employees
																{
																				Employee_ID = 2,
																				Emp_First_Name = "Test_Emp_Two",
																				Emp_Last_Name = "Employee_Two",
																				Emp_Initials = "TE2"
																});
												}
												#endregion

												//Seed Ingredients
												#region Ingredients Type Seeds


												if (!context.Ingredients.Any(x => x.Ingredient_ID == 2))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Granulated Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 3))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Honey" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 4))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Agave" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 5))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Xylitol" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 6))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Swerre" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 7))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Sugar Free" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 8))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Organic Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 9))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Tapiocca Powdered Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 10))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Coconut" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 11))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar", Ingredient_Name = "Monk Fruit" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 12))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Flour", Ingredient_Name = "Almond Flour" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_ID == 13))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Flour", Ingredient_Name = "Brown Rice Flour" }); }

												#endregion

												//Seed OrderSizes Types
												#region OrderSizes Type Seeds

												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 2))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "2", Order_Size = 6, Number_Of_Layers = 2 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 3))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "2", Order_Size = 8, Number_Of_Layers = 3 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 4))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "2", Order_Size = 10, Number_Of_Layers = 3 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 5))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "2", Order_Size = 12, Number_Of_Layers = 3 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 6))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "11", Order_Size = 6, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 7))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "11", Order_Size = 12, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 8))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "5", Order_Size = 6, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 9))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "5", Order_Size = 12, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 10))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "7", Order_Size = 9, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 11))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "12", Order_Size = 6, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 12))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "12", Order_Size = 12, Number_Of_Layers = 0 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 13))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "10", Order_Size = 1812, Number_Of_Layers = 2 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size_ID == 14))
												{ context.OrderSizes.Add(new OrderSizes { Product_Type_ID = "3", Order_Size = 12, Number_Of_Layers = 0 }); }

												#endregion

												//Seed Product Types
												#region Product Type Seeds
												if (!context.ProductTypes.Any(u => u.Name == "Bread"))
												{ context.ProductTypes.Add(new ProductType { Name = "Bread", Id = 1 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Cake"))
												{ context.ProductTypes.Add(new ProductType { Name = "Cake", Id = 2 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Cookie"))
												{ context.ProductTypes.Add(new ProductType { Name = "Cookie", Id = 3 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Doughnut"))
												{ context.ProductTypes.Add(new ProductType { Name = "Doughnut", Id = 4 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Muffin"))
												{ context.ProductTypes.Add(new ProductType { Name = "Muffin", Id = 5 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Other Sweet"))
												{ context.ProductTypes.Add(new ProductType { Name = "Other Sweet", Id = 6 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Pie"))
												{ context.ProductTypes.Add(new ProductType { Name = "Pie", Id = 7 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Protien Bar"))
												{ context.ProductTypes.Add(new ProductType { Name = "Protien Bar", Id = 8 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Savory Item"))
												{ context.ProductTypes.Add(new ProductType { Name = "Savory Item", Id = 9 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Sheet Cake"))
												{ context.ProductTypes.Add(new ProductType { Name = "Sheet Cake", Id = 10 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Cupcake"))
												{ context.ProductTypes.Add(new ProductType { Name = "Cupcake", Id = 11 }); }

												if (!context.ProductTypes.Any(u => u.Name == "Buns"))
												{ context.ProductTypes.Add(new ProductType { Name = "Buns", Id = 12 }); }
												#endregion

												//Seed Dietary Restrictions
												#region Dietary Restrictions Seeds
												if (!context.DietaryRestrictions.Any(u => u.RestrictionName == "Generic"))
												{ context.DietaryRestrictions.Add(new DietaryRestriction { RestrictionName = "Generic", Id = 1 }); }

												if (!context.DietaryRestrictions.Any(u => u.RestrictionName == "Keto"))
												{ context.DietaryRestrictions.Add(new DietaryRestriction { RestrictionName = "Keto", Id = 2 }); }

												if (!context.DietaryRestrictions.Any(u => u.RestrictionName == "Paleo"))
												{ context.DietaryRestrictions.Add(new DietaryRestriction { RestrictionName = "Paleo", Id = 3 }); }
												#endregion

												//Seed Finishing Types
												#region Finishing Type Seeds
												if (!context.FinishingsTypes.Any(u => u.Name == "Filling"))
												{ context.FinishingsTypes.Add(new FinishingsType { Name = "Filling" }); }

												if (!context.FinishingsTypes.Any(u => u.Name == "Garnish"))
												{ context.FinishingsTypes.Add(new FinishingsType { Name = "Garnish" }); }

												if (!context.FinishingsTypes.Any(u => u.Name == "Glaze"))
												{ context.FinishingsTypes.Add(new FinishingsType { Name = "Glaze" }); }

												if (!context.FinishingsTypes.Any(u => u.Name == "Icing"))
												{ context.FinishingsTypes.Add(new FinishingsType { Name = "Icing" }); }

												if (!context.FinishingsTypes.Any(u => u.Name == "Topping"))
												{ context.FinishingsTypes.Add(new FinishingsType { Name = "Topping" }); }
												#endregion

												//Seed Product Finishings
												#region Product Finishings Seeds
												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Banana"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Banana", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Belgian Chocolate"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Belgian Chocolate", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Blueberry"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Blueberry", FinishTypeId = 3 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Blueberry Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Blueberry Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Brown Sugar Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Brown Sugar Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Butterscotch Sauce"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Butterscotch Sauce", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Canadian Maple Syrup"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Canadian Maple Syrup", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Candied Pecan"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Candied Pecan", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Caramel"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Caramel", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Caramel Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Caramel Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Cardamom Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Cardamom Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Carrots"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Carrots", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Cherry Preserves"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Cherry Preserves", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Chocolate Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Chocolate Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Chocolate Chip Cookies"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Chocolate Chip Cookies", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Chocolate Espresso Beans"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Chocolate Esspresso Beans", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Chocolate Shards"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Chocolate Shards", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Cinnamon Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Cinnamon Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Cinnamon Sugar"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Cinnamon Sugar", FinishTypeId = 3 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Classic White"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Classic White", FinishTypeId = 3 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Cocoa"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Cocoa", FinishTypeId = 3 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Coconut"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Coconut", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Coconut", FinishTypeId = 4 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Coconut", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Coffee Beans"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Coffee Beans", FinishTypeId = 2 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Cookie Dough"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Cookie Dough", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Crushed Peppermint"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Crushed Peppermint", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Crushed Peppermint", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Espresso Buttercream "))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Espresso Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Espresso Infused"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Espresso Infused", FinishTypeId = 3 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Fresh Cherry"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fresh Cherry", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Fresh Raspberry"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fresh Raspberry", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fresh Raspberry", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Fresh Strawberry"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fresh Strawberry", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fresh Strawberry", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Fudge Sauce"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fudge Sauce", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Fudgy Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Fudgy Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Ganache"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Ganache", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "German Chocolate Frosting"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "German Chocolate Frosting", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Graham Cracker"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Graham Craker", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Lemon Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Lemon Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Lemon Meringue Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Lemon Meringue Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Lemon Shortbread"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Lemon Shortbread", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Marbled Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Marbled Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Nuts"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Nuts", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Peach Slivers"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Peach Slivers", FinishTypeId = 2 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Peaches"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Peaches", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Pecans"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Pecans", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Pineapple"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Pineapple", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Pink Tripple Berry Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Pink Tripple Berry Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Pralines"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Pralines", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Pralines", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Raisins"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Raisins", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Raspberry Pistachio Preserves"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Raspberry Pistachio Preserves", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Raspberry Preserves"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Raspberry Preserves", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Semi-sweet Espresso Ganache"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Semi-sweet Espresso Ganache", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Spiced Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Spiced Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Spiced Chocolate"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Spiced Chocolate", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Sprinkles"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Sprinkles", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Stewed Apples"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Stewed Apples", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Stewed Apples", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Strawberry"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Strawberry", FinishTypeId = 3 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Strawberry Preserves"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Strawberry Preserves", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Sweet Coconut Cream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Sweet Coconut Cream", FinishTypeId = 1 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Sweet Sugar Glaze"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Sweet Sugar Glaze", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Toasted Coconut"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Toasted Coconut", FinishTypeId = 2 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Toasted Marshmallow Fluff"))
												{
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Toasted Marshmallow Fluff", FinishTypeId = 1 });
																context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Toasted Marshmallow Fluff", FinishTypeId = 5 });
												}

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Toasted Pecans"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Toasted Pecans", FinishTypeId = 5 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Vanilla Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Vanilla Buttercream", FinishTypeId = 4 }); }

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Vegan Buttercream"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Vegan Buttercream", FinishTypeId = 4 }); }
												#endregion

												//Seed Products AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH (end the suffering ;-;)
												#region Product Type Seeds
												if (!context.Products.Any(x => x.Product_Flavor == "Almond Butter"))
												{ context.Products.Add(new Product { ProductId = 82, TypeId = 8, RestrictionId = 1, Product_Flavor = "Almond Butter", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Apple"))
												{ context.Products.Add(new Product { ProductId = 107, TypeId = 7, RestrictionId = 1, Product_Flavor = "Apple", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Apple Butter"))
												{ context.Products.Add(new Product { ProductId = 55, TypeId = 2, RestrictionId = 1, Product_Flavor = "Apple Butter", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Apple Caramel Butterscotch"))
												{
																context.Products.Add(new Product { ProductId = 96, TypeId = 3, RestrictionId = 1, Product_Flavor = "Apple Caramel Butterscotch", Product_Description = "Loaded with granny smith apples and rolled oats,topped with homemade caramel and butterscotch sauce, these beauties won first place at the Dixie Classic Fair for a good reason. ", Seasonal = false });
																context.Products.Add(new Product { ProductId = 85, TypeId = 3, RestrictionId = 1, Product_Flavor = "Apple Caramel Butterscotch", Product_Description = "(gluten free only)", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Apple Harvest"))
												{
																context.Products.Add(new Product { ProductId = 71, TypeId = 4, RestrictionId = 1, Product_Flavor = "Apple Harvest", Product_Description = "Spiced donut topped with organic stewed apples.", Seasonal = false });
																context.Products.Add(new Product { ProductId = 10, TypeId = 2, RestrictionId = 1, Product_Flavor = "Apple Harvest", Product_Description = "A spiced cake loaded with organic stewed apples, topped with homemade caramel buttercream. A taste of Fall.", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Apple Streudel"))
												{ context.Products.Add(new Product { ProductId = 100, TypeId = 5, RestrictionId = 1, Product_Flavor = "Apple Streudel", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Baklava"))
												{ context.Products.Add(new Product { ProductId = 120, TypeId = 6, RestrictionId = 1, Product_Flavor = "Baklava", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Banana Bread"))
												{ context.Products.Add(new Product { ProductId = 144, TypeId = 1, RestrictionId = 3, Product_Flavor = "Banana Bread", Product_Description = "Incredibly moist, chewy, and spiced to perfection. Sweetened with honey.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Beef + Eggplant Lasagna"))
												{ context.Products.Add(new Product { ProductId = 129, TypeId = 9, RestrictionId = 1, Product_Flavor = "Beef + Eggplant Lasagna", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Berry Bars"))
												{ context.Products.Add(new Product { ProductId = 115, TypeId = 6, RestrictionId = 1, Product_Flavor = "Berry Bars", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Black Forest"))
												{ context.Products.Add(new Product { ProductId = 18, TypeId = 2, RestrictionId = 1, Product_Flavor = "Black Forest", Product_Description = "A rich chocolate cake layered with homemade cherry preserves, iced in vanilla buttercream and topped with chocolate shards.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Blueberry"))
												{
																context.Products.Add(new Product { ProductId = 66, TypeId = 4, RestrictionId = 1, Product_Flavor = "Blueberry", Product_Description = "Bursting with flavor, vanilla donut laced and topped with organic blueberries", Seasonal = false });
																context.Products.Add(new Product { ProductId = 109, TypeId = 7, RestrictionId = 1, Product_Flavor = "Blueberry", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Broccoli + Potato Cheese Casserole"))
												{
																context.Products.Add(new Product { ProductId = 128, TypeId = 9, RestrictionId = 1, Product_Flavor = "Broccoli + Potato Cheese Casserole", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 129, TypeId = 9, RestrictionId = 1, Product_Flavor = "Broccoli + Potato Cheese Casserole", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Brookie"))
												{ context.Products.Add(new Product { ProductId = 26, TypeId = 2, RestrictionId = 1, Product_Flavor = "Brookie", Product_Description = "Half brownie + half cookie = wholly delicious. Alternating layers of rich chocolate and chocolate chip cake, iced in our signature cookie dough frosting. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Brookies"))
												{ context.Products.Add(new Product { ProductId = 94, TypeId = 3, RestrictionId = 1, Product_Flavor = "Brookies", Product_Description = "Half Brownie + Half Chocolate Chip = 100% amazing.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Brownies"))
												{ context.Products.Add(new Product { ProductId = 118, TypeId = 6, RestrictionId = 1, Product_Flavor = "Brownies", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cannoli"))
												{ context.Products.Add(new Product { ProductId = 123, TypeId = 6, RestrictionId = 1, Product_Flavor = "Cannoli", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Caramel Cappuccino "))
												{ context.Products.Add(new Product { ProductId = 31, TypeId = 2, RestrictionId = 1, Product_Flavor = "Caramel Cappuccino ", Product_Description = "Vanilla cake swirled with homemade caramel, hot fudge, and espresso, iced in our signature espresso buttercream and topped with more decadent caramel and hot fudge.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Carrot Cake Muffins"))
												{ context.Products.Add(new Product { ProductId = 143, TypeId = 5, RestrictionId = 3, Product_Flavor = "Carrot Cake Muffins", Product_Description = "Loaded with carrot, apple, raisins, spices, and more! Topped with a silky lemon meringue buttercream. Sweetened with honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chai Spice"))
												{ context.Products.Add(new Product { ProductId = 63, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chai Spice", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cheesecake Bars"))
												{ context.Products.Add(new Product { ProductId = 175, TypeId = 6, RestrictionId = 2, Product_Flavor = "Cheesecake Bars", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate"))
												{ context.Products.Add(new Product { ProductId = 78, TypeId = 8, RestrictionId = 1, Product_Flavor = "Chocolate", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Biscotti"))
												{ context.Products.Add(new Product { ProductId = 141, TypeId = 6, RestrictionId = 3, Product_Flavor = "Chocolate Biscotti", Product_Description = "Addictive! Almond flour and dutch cocoa biscotti, loaded with nuts. Sweetened with honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Caramel"))
												{ context.Products.Add(new Product { ProductId = 32, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Caramel", Product_Description = "Rich chocolate cake filled and topped with our decadent homemade caramel.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Cherry Berry"))
												{ context.Products.Add(new Product { ProductId = 35, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Cherry Berry", Product_Description = "A rich chocolate cake layered with homemade 5 berry preserves and iced in silky chocolate buttercream.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Chip"))
												{ context.Products.Add(new Product { ProductId = 104, TypeId = 5, RestrictionId = 1, Product_Flavor = "Chocolate Chip", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Chip Banana Bread"))
												{ context.Products.Add(new Product { ProductId = 117, TypeId = 6, RestrictionId = 1, Product_Flavor = "Chocolate Chip Banana Bread", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Chip Cookie Dough"))
												{ context.Products.Add(new Product { ProductId = 24, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Chip Cookie Dough", Product_Description = "Rich chocolate cake iced in our signature cookie dough frosting. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Chip Espresso"))
												{ context.Products.Add(new Product { ProductId = 87, TypeId = 3, RestrictionId = 1, Product_Flavor = "Chocolate Chip Espresso", Product_Description = "For all you coffee addicts, ehm, I mean, coffee *lovers*, this cookie is just for you! We incorporate Fortuna Espresso into our classic chocolate chip cookie base to give you that extra kick you need to get going! ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Coconut Cream"))
												{ context.Products.Add(new Product { ProductId = 19, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Coconut Cream", Product_Description = "Rich chocolate cake filled with homemade sweet coconut cream, iced in classic chocolate buttercream, garnished with organic toasted coconut. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Espresso"))
												{ context.Products.Add(new Product { ProductId = 5, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Espresso", Product_Description = "Rich chocolate cake infused with locally roasted Fortuna coffee, iced in our signature chocolate espresso buttercream and garnished with coffee beans.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Meringue Muffins"))
												{ context.Products.Add(new Product { ProductId = 142, TypeId = 5, RestrictionId = 3, Product_Flavor = "Chocolate Meringue Muffins", Product_Description = "Dense almond flour chocolate cake, topped with a silky smooth chocolate meringue. Sweetened with honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Orange"))
												{ context.Products.Add(new Product { ProductId = 46, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Orange", Product_Description = "The perfect flavor combo of decadence, dutch cocoa meets organic citrus. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Orange Biscotti"))
												{ context.Products.Add(new Product { ProductId = 176, TypeId = 6, RestrictionId = 2, Product_Flavor = "Chocolate Orange Biscotti", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Peppermint"))
												{ context.Products.Add(new Product { ProductId = 22, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Peppermint", Product_Description = "Rich chocolate cake laced with peppermint, iced in vanilla buttercream, filled and topped with crushed peppermints", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Pumpkin"))
												{ context.Products.Add(new Product { ProductId = 62, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Pumpkin", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Raspberry"))
												{ context.Products.Add(new Product { ProductId = 13, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Raspberry", Product_Description = "Rich chocolate cake filled with organic raspberry preserves, iced in classic chocolate buttercream and topped with fresh raspberries. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Strawberry"))
												{ context.Products.Add(new Product { ProductId = 7, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Strawberry", Product_Description = "Rich chocolate cake filled with organic strawberry preserves, iced with fudgy buttercream.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Chocolate Turtle"))
												{
																context.Products.Add(new Product { ProductId = 58, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chocolate Turtle", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 70, TypeId = 4, RestrictionId = 1, Product_Flavor = "Chocolate Turtle", Product_Description = "Signature chocolate topped with toasted pecans, homemade caramel, and Belgian chocolate drizzle", Seasonal = false });
																context.Products.Add(new Product { ProductId = 156, TypeId = 2, RestrictionId = 2, Product_Flavor = "Chocolate Turtle", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Chunky Monkey"))
												{ context.Products.Add(new Product { ProductId = 52, TypeId = 2, RestrictionId = 1, Product_Flavor = "Chunky Monkey", Product_Description = "Banana Cake bursting with flavor, iced in Cinnamon Buttercream, and topped with Chocolate Ganache, this one is a year round best seller!", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cinnamon Bun"))
												{ context.Products.Add(new Product { ProductId = 51, TypeId = 2, RestrictionId = 1, Product_Flavor = "Cinnamon Bun", Product_Description = "The ultimate comfort cake. One bite summons visions of sweater weather lazy couch days. Cinnamon swirl cake iced in a brown sugar buttercream and topped with a sweet sugar glaze", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cinnamon Buns"))
												{
																context.Products.Add(new Product { ProductId = 138, TypeId = 6, RestrictionId = 3, Product_Flavor = "Cinnamon Buns", Product_Description = "Little rolls of cinnamon perfection, topped with coconut cream frosting. Sweetened with honey and coconut sugar", Seasonal = false });
																context.Products.Add(new Product { ProductId = 124, TypeId = 6, RestrictionId = 1, Product_Flavor = "Cinnamon Buns", Product_Description = "Famous", Seasonal = false });
																context.Products.Add(new Product { ProductId = 174, TypeId = 6, RestrictionId = 2, Product_Flavor = "Cinnamon Buns", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Cinnamon Sugar"))
												{
																context.Products.Add(new Product { ProductId = 134, TypeId = 1, RestrictionId = 1, Product_Flavor = "Cinnamon Sugar", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 172, TypeId = 4, RestrictionId = 1, Product_Flavor = "Cinnamon Sugar", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Citrus Twist"))
												{ context.Products.Add(new Product { ProductId = 59, TypeId = 2, RestrictionId = 1, Product_Flavor = "Citrus Twist", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Classic"))
												{ context.Products.Add(new Product { ProductId = 132, TypeId = 1, RestrictionId = 1, Product_Flavor = "Classic", Product_Description = "The BEST gluten Free, vegan Sandwich Bread in town", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Classic Chocolate Chip"))
												{ context.Products.Add(new Product { ProductId = 86, TypeId = 3, RestrictionId = 1, Product_Flavor = "Classic Chocolate Chip", Product_Description = "Our classic chocolate chip cookies are the real deal...if you don't believe it, check out our customer reviews! Loaded with semi-sweet Belgian chocolate chips, they will leave you begging for more.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Classic Vanilla"))
												{ context.Products.Add(new Product { ProductId = 2, TypeId = 2, RestrictionId = 1, Product_Flavor = "Classic Vanilla", Product_Description = "Our classic vanilla cake is likewise noteworthy in its supreme moistness and perfect crumb. This recipe is old, as in WWII old...so you know for it to have lasted this long, it has to be good! Paired with our vanilla buttercream, this one is definitely a crowd-pleaser.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Coconut Cream"))
												{
																context.Products.Add(new Product { ProductId = 20, TypeId = 2, RestrictionId = 1, Product_Flavor = "Coconut Cream", Product_Description = "White cake filled with homemade sweet coconut cream, iced in vanilla buttercream and garnished with toasted coconut ", Seasonal = false });
																context.Products.Add(new Product { ProductId = 112, TypeId = 7, RestrictionId = 1, Product_Flavor = "Coconut Cream", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Cookie Crunch"))
												{ context.Products.Add(new Product { ProductId = 25, TypeId = 2, RestrictionId = 1, Product_Flavor = "Cookie Crunch", Product_Description = "Rich chocolate cake, iced in vanilla buttercream, and topped and filled with homemade chocolate chip cookie crumbles.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cookie Dough"))
												{ context.Products.Add(new Product { ProductId = 23, TypeId = 2, RestrictionId = 1, Product_Flavor = "Cookie Dough", Product_Description = "A definite bestseller, this is a winner with kids and adults alike. Our chocolate chip cake, iced in our signature cookie dough frosting. Yum yum yum! ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cookies n Cream"))
												{
																context.Products.Add(new Product { ProductId = 56, TypeId = 2, RestrictionId = 1, Product_Flavor = "Cookies n Cream", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 76, TypeId = 4, RestrictionId = 1, Product_Flavor = "Cookies n Cream", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Cranberry"))
												{ context.Products.Add(new Product { ProductId = 79, TypeId = 8, RestrictionId = 1, Product_Flavor = "Cranberry", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cranberry Orange Cookie Cake"))
												{ context.Products.Add(new Product { ProductId = 139, TypeId = 2, RestrictionId = 3, Product_Flavor = "Cranberry Orange Cookie Cake", Product_Description = "Almond flour cookie cake, laced with organic orange and loaded with cranberries. A perfect balance of sweet and tang. Sweetened with honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cranberry Orange Ginger"))
												{ context.Products.Add(new Product { ProductId = 88, TypeId = 3, RestrictionId = 1, Product_Flavor = "Cranberry Orange Ginger", Product_Description = "The title says it all. These cookies are a party of flavor in your mouth and a best seller! ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Cupcakes"))
												{ context.Products.Add(new Product { ProductId = 116, TypeId = 6, RestrictionId = 1, Product_Flavor = "Cupcakes", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Dark Chocolate Cookie Cake"))
												{ context.Products.Add(new Product { ProductId = 140, TypeId = 2, RestrictionId = 3, Product_Flavor = "Dark Chocolate Cookie Cake", Product_Description = "Almond flour and dutch cocoa cookie cake. Sweetened with honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Death By Chocolate"))
												{ context.Products.Add(new Product { ProductId = 102, TypeId = 5, RestrictionId = 1, Product_Flavor = "Death By Chocolate", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Double Chocolate"))
												{
																context.Products.Add(new Product { ProductId = 64, TypeId = 4, RestrictionId = 1, Product_Flavor = "Double Chocolate", Product_Description = "Our signature chocolate donut with dark dutch cocoa glaze", Seasonal = false });
																context.Products.Add(new Product { ProductId = 3, TypeId = 2, RestrictionId = 1, Product_Flavor = "Double Chocolate", Product_Description = "Incredibly moist, rich, and delicious. Paired with fudgy, silky buttercream, it is a year-round best seller!", Seasonal = false });
																context.Products.Add(new Product { ProductId = 165, TypeId = 5, RestrictionId = 2, Product_Flavor = "Double Chocolate", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 157, TypeId = 4, RestrictionId = 2, Product_Flavor = "Double Chocolate", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 146, TypeId = 2, RestrictionId = 2, Product_Flavor = "Double Chocolate", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Dreamsicle"))
												{ context.Products.Add(new Product { ProductId = 41, TypeId = 2, RestrictionId = 1, Product_Flavor = "Dreamsicle", Product_Description = "Reminiscent of orange push pops and the accompanying endless carefree childhood summer days", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Earl Grey"))
												{ context.Products.Add(new Product { ProductId = 75, TypeId = 4, RestrictionId = 1, Product_Flavor = "Earl Grey", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Eclairs"))
												{ context.Products.Add(new Product { ProductId = 122, TypeId = 6, RestrictionId = 1, Product_Flavor = "Eclairs", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Espresso"))
												{ context.Products.Add(new Product { ProductId = 73, TypeId = 4, RestrictionId = 1, Product_Flavor = "Espresso", Product_Description = "Signature chocolate topped with espresso infused glaze. Coffee lovers rejoice! ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Five-Berry"))
												{ context.Products.Add(new Product { ProductId = 111, TypeId = 7, RestrictionId = 1, Product_Flavor = "Five-Berry", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Fresh Strawberry"))
												{ context.Products.Add(new Product { ProductId = 9, TypeId = 2, RestrictionId = 1, Product_Flavor = "Fresh Strawberry", Product_Description = "vanilla cake loaded with juicy, organic fresh strawberry chunks and topped with the same. ", Seasonal = true }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Fudge Marble"))
												{ context.Products.Add(new Product { ProductId = 40, TypeId = 2, RestrictionId = 1, Product_Flavor = "Fudge Marble", Product_Description = "For the indecisive-the best of both worlds. Vanilla cake swirled with Belgian chocolate, iced in a marbled buttercream. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Fully Loaded Southern Carrot"))
												{ context.Products.Add(new Product { ProductId = 39, TypeId = 2, RestrictionId = 1, Product_Flavor = "Fully Loaded Southern Carrot", Product_Description = "Laden with Carrots, Spices, Nuts, Pineapple, Coconut, Raisins and topped with vegan buttercream frosting, this goldmine is the FULL EXPERIENCE!", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "German Chocolate"))
												{
																context.Products.Add(new Product { ProductId = 57, TypeId = 2, RestrictionId = 1, Product_Flavor = "German Chocolate", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 16, TypeId = 2, RestrictionId = 1, Product_Flavor = "German Chocolate", Product_Description = "Rich chocolate cake filled and iced with our signature German Chocolate frosting, LOADED with coconut and toasted pecans. A holiday favorite.", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Ginger Zingers"))
												{ context.Products.Add(new Product { ProductId = 98, TypeId = 3, RestrictionId = 1, Product_Flavor = "Ginger Zingers", Product_Description = "Soft and chewy, with the flavor of Moravian cookies, and an extra zing of ginger. A holiday essential.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Gingerade"))
												{ context.Products.Add(new Product { ProductId = 50, TypeId = 2, RestrictionId = 1, Product_Flavor = "Gingerade", Product_Description = "Spiced ginger cake iced with a twist of refreshing lemon buttercream. A unique and perfectly balanced pairing. YUM. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Gingerbread"))
												{
																context.Products.Add(new Product { ProductId = 37, TypeId = 2, RestrictionId = 1, Product_Flavor = "Gingerbread", Product_Description = "Baking spirits bright, this seasonal favorite signals the start of the holidays! An incredibly moist molasses cake spiced to perfection, iced in a fluffy vanilla buttercream.", Seasonal = false });
																context.Products.Add(new Product { ProductId = 92, TypeId = 3, RestrictionId = 1, Product_Flavor = "Gingerbread", Product_Description = "Wow. We have literally converted gingerbread haters (crazy, right?) into die-hard fans where these cookies are concerned. Our men of ginger are the perfect consistency of firm yet chewy and are spiced reeeal nice! ", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Hemp"))
												{ context.Products.Add(new Product { ProductId = 80, TypeId = 8, RestrictionId = 1, Product_Flavor = "Hemp", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Hot Cocoa Snickerdoodle"))
												{
																context.Products.Add(new Product { ProductId = 38, TypeId = 2, RestrictionId = 1, Product_Flavor = "Hot Cocoa Snickerdoodle", Product_Description = "Mexican hot chocolate cake, frosted in a spiced chocolate buttercream", Seasonal = false });
																context.Products.Add(new Product { ProductId = 91, TypeId = 3, RestrictionId = 1, Product_Flavor = "Hot Cocoa Snickerdoodle", Product_Description = "Favorite holiday cookie meets favorite holiday drink. Chewy cocoa cookies rolled in cinnamon and sugar. Sugar, spice, and everything nice: that's what these are made of! Sold by the dozen.", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Hot Fudge Sundae"))
												{ context.Products.Add(new Product { ProductId = 28, TypeId = 2, RestrictionId = 1, Product_Flavor = "Hot Fudge Sundae", Product_Description = "Rich chocolate cake layered with homemade hot fudge sauce and sprinkles, iced in vanilla buttercream. Let�s get the party started!", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Hummingbird"))
												{ context.Products.Add(new Product { ProductId = 17, TypeId = 2, RestrictionId = 1, Product_Flavor = "Hummingbird", Product_Description = "A southern classic done right. Banana, pineapple, pecans, and spices galore. Simply refreshing, melt-in-your-mouth, delicious.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Kalamata Olive"))
												{ context.Products.Add(new Product { ProductId = 135, TypeId = 1, RestrictionId = 1, Product_Flavor = "Kalamata Olive", Product_Description = "The BEST gluten Free, vegan Sandwich Bread in town", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Lemon Blueberry"))
												{
																context.Products.Add(new Product { ProductId = 130, TypeId = 5, RestrictionId = 1, Product_Flavor = "Lemon Blueberry", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 47, TypeId = 2, RestrictionId = 1, Product_Flavor = "Lemon Blueberry", Product_Description = "BESTSELLER!! Luscious lemon cake, iced in our organic blueberry infused buttercream", Seasonal = false });
																context.Products.Add(new Product { ProductId = 155, TypeId = 2, RestrictionId = 2, Product_Flavor = "Lemon Blueberry", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Lemon Crunch"))
												{ context.Products.Add(new Product { ProductId = 74, TypeId = 4, RestrictionId = 1, Product_Flavor = "Lemon Crunch", Product_Description = "Light lemon donut topped with classic white glaze and lemon shortbread. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Lemon Curd Fruit Tarts"))
												{ context.Products.Add(new Product { ProductId = 113, TypeId = 6, RestrictionId = 1, Product_Flavor = "Lemon Curd Fruit Tarts", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Lemon Lavender"))
												{ context.Products.Add(new Product { ProductId = 61, TypeId = 2, RestrictionId = 1, Product_Flavor = "Lemon Lavender", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Lemon Shortbread"))
												{ context.Products.Add(new Product { ProductId = 99, TypeId = 3, RestrictionId = 1, Product_Flavor = "Lemon Shortbread", Product_Description = "Featuring organic lemon and melt-in-your-mouth delicious. Need we say more? ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Luscious Lemon"))
												{ context.Products.Add(new Product { ProductId = 21, TypeId = 2, RestrictionId = 1, Product_Flavor = "Luscious Lemon", Product_Description = "Light lemon cake, iced in a refreshing lemon buttercream. Simplicity bursting with flavor.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Maple Praline"))
												{
																context.Products.Add(new Product { ProductId = 15, TypeId = 2, RestrictionId = 1, Product_Flavor = "Maple Praline", Product_Description = "Moist cake, laced with pure Canadian maple syrup, frosted in a spiced buttercream, filled and topped with homemade pralines ", Seasonal = false });
																context.Products.Add(new Product { ProductId = 67, TypeId = 4, RestrictionId = 1, Product_Flavor = "Maple Praline", Product_Description = "Maple donut topped with housemade candied pecans. Reminiscent of pancakes", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Mexican Hot Chocolate"))
												{
																context.Products.Add(new Product { ProductId = 168, TypeId = 5, RestrictionId = 2, Product_Flavor = "Mexican Hot Chocolate", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 149, TypeId = 2, RestrictionId = 2, Product_Flavor = "Mexican Hot Chocolate", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 160, TypeId = 4, RestrictionId = 2, Product_Flavor = "Mexican Hot Chocolate", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Million Dollar Chocolate Mousse"))
												{ context.Products.Add(new Product { ProductId = 119, TypeId = 6, RestrictionId = 1, Product_Flavor = "Million Dollar Chocolate Mousse", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Mixed Berry"))
												{
																context.Products.Add(new Product { ProductId = 153, TypeId = 2, RestrictionId = 2, Product_Flavor = "Mixed Berry", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 164, TypeId = 4, RestrictionId = 2, Product_Flavor = "Mixed Berry", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 172, TypeId = 5, RestrictionId = 2, Product_Flavor = "Mixed Berry", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Molasses"))
												{ context.Products.Add(new Product { ProductId = 11, TypeId = 2, RestrictionId = 1, Product_Flavor = "Molasses", Product_Description = "The quintessential comfort cake. Moist cake swirled with dark molasses, iced in a brown sugar buttercream.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Oatmeal Raisin"))
												{ context.Products.Add(new Product { ProductId = 90, TypeId = 3, RestrictionId = 1, Product_Flavor = "Oatmeal Raisin", Product_Description = "Soft, chewy, and packed with whole rolled oat, molasses, coconut, and extra raisins. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Orange Dreamsicle"))
												{ context.Products.Add(new Product { ProductId = 154, TypeId = 2, RestrictionId = 2, Product_Flavor = "Orange Dreamsicle", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Peaches n'Cream"))
												{ context.Products.Add(new Product { ProductId = 8, TypeId = 2, RestrictionId = 1, Product_Flavor = "Peaches n'Cream", Product_Description = "Moist cake loaded with juicy peach chunks, iced in a cardamom buttercream and garnished with peach slivers. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pecan"))
												{ context.Products.Add(new Product { ProductId = 110, TypeId = 7, RestrictionId = 1, Product_Flavor = "Pecan", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pecan Tart"))
												{ context.Products.Add(new Product { ProductId = 145, TypeId = 6, RestrictionId = 3, Product_Flavor = "Pecan Tart", Product_Description = "Unbelievably DELICIOUS. Loaded with nuts and spices. Sweetened honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pi�a Colada (Virgin)"))
												{ context.Products.Add(new Product { ProductId = 42, TypeId = 2, RestrictionId = 1, Product_Flavor = "Pi�a Colada (Virgin)", Product_Description = "The cake where it all began. Loaded with fresh pineapple and toasted coconut, utterly refreshing, tropical, and irresistible. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pineapple Caramel"))
												{ context.Products.Add(new Product { ProductId = 30, TypeId = 2, RestrictionId = 1, Product_Flavor = "Pineapple Caramel", Product_Description = "Tropical meets comfort with our moist, spiced pineapple cake filled and topped with our decadent homemade caramel. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pink Lady"))
												{ context.Products.Add(new Product { ProductId = 44, TypeId = 2, RestrictionId = 1, Product_Flavor = "Pink Lady", Product_Description = "Rich chocolate cake iced in a signature pink triple berry buttercream. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pizza"))
												{ context.Products.Add(new Product { ProductId = 172, TypeId = 9, RestrictionId = 2, Product_Flavor = "Pizza", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pretzels"))
												{ context.Products.Add(new Product { ProductId = 125, TypeId = 9, RestrictionId = 1, Product_Flavor = "Pretzels", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Protein Cookies"))
												{ context.Products.Add(new Product { ProductId = 137, TypeId = 3, RestrictionId = 3, Product_Flavor = "Protein Cookies", Product_Description = "Our signature bakery item. 10 grams of protein per cookie, notes of almond + sesame + vanilla, chewy and addictive. Sweetened with honey. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pumpkin"))
												{ context.Products.Add(new Product { ProductId = 106, TypeId = 7, RestrictionId = 1, Product_Flavor = "Pumpkin", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pumpkin Oat"))
												{ context.Products.Add(new Product { ProductId = 101, TypeId = 5, RestrictionId = 1, Product_Flavor = "Pumpkin Oat", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Pumpkin Spice"))
												{
																context.Products.Add(new Product { ProductId = 29, TypeId = 2, RestrictionId = 1, Product_Flavor = "Pumpkin Spice", Product_Description = "This masterpiece won the WBFJ cake competition at the Dixie Classic Fair and is our fall bestseller by far! Moist spiced pumpkin cake iced with homemade caramel buttercream...need we say more? ", Seasonal = false });
																context.Products.Add(new Product { ProductId = 167, TypeId = 5, RestrictionId = 2, Product_Flavor = "Pumpkin Spice", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 159, TypeId = 4, RestrictionId = 2, Product_Flavor = "Pumpkin Spice", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 148, TypeId = 2, RestrictionId = 2, Product_Flavor = "Pumpkin Spice", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Raisins"))
												{ context.Products.Add(new Product { ProductId = 84, TypeId = 8, RestrictionId = 1, Product_Flavor = "Raisins", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Raspberry Lemonade"))
												{ context.Products.Add(new Product { ProductId = 49, TypeId = 2, RestrictionId = 1, Product_Flavor = "Raspberry Lemonade", Product_Description = "Luscious lemon cake filled with organic raspberry preserves, iced in a light lemon buttercream. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Raspberry Ripple"))
												{ context.Products.Add(new Product { ProductId = 45, TypeId = 2, RestrictionId = 1, Product_Flavor = "Raspberry Ripple", Product_Description = "Best seller alert! Light and refreshing, this cake is loaded with organic raspberries, cherries, strawberries (and more!) both in the cake and the frosting.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Rice Pudding"))
												{ context.Products.Add(new Product { ProductId = 114, TypeId = 6, RestrictionId = 1, Product_Flavor = "Rice Pudding", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Rosemary Garlic"))
												{ context.Products.Add(new Product { ProductId = 133, TypeId = 1, RestrictionId = 1, Product_Flavor = "Rosemary Garlic", Product_Description = "The BEST gluten Free, vegan Sandwich Bread in town", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Samoa"))
												{ context.Products.Add(new Product { ProductId = 69, TypeId = 4, RestrictionId = 1, Product_Flavor = "Samoa", Product_Description = "Vanilla donut, caramel core, topped with coconut frosting and Belgian chocolate. Reminiscent of caramel delights", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Seeded"))
												{ context.Products.Add(new Product { ProductId = 136, TypeId = 1, RestrictionId = 1, Product_Flavor = "Seeded", Product_Description = "The BEST gluten Free, vegan Sandwich Bread in town", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Shepherd's Pie"))
												{ context.Products.Add(new Product { ProductId = 131, TypeId = 9, RestrictionId = 1, Product_Flavor = "Shepherd's Pie", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "S'More"))
												{
																context.Products.Add(new Product { ProductId = 68, TypeId = 4, RestrictionId = 1, Product_Flavor = "S'More", Product_Description = "Signature chocolate donut filled with homemade toasted marshmallow fluff and topped with graham cracker", Seasonal = false });
																context.Products.Add(new Product { ProductId = 12, TypeId = 2, RestrictionId = 1, Product_Flavor = "S'More", Product_Description = "Also known as the Campfire Cake, children and adults alike LOVE one. Rich chocolate cake filled with homemade + toasted marshmallow fluff, iced in chocolate buttercream and topped with graham cracker and ganache. Ooh la la!", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "S'more Brownies"))
												{ context.Products.Add(new Product { ProductId = 177, TypeId = 6, RestrictionId = 2, Product_Flavor = "S'more Brownies", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Southern Carrot"))
												{
																context.Products.Add(new Product { ProductId = 169, TypeId = 5, RestrictionId = 2, Product_Flavor = "Southern Carrot", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 150, TypeId = 2, RestrictionId = 2, Product_Flavor = "Southern Carrot", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 161, TypeId = 4, RestrictionId = 2, Product_Flavor = "Southern Carrot", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Spanakopita"))
												{ context.Products.Add(new Product { ProductId = 130, TypeId = 9, RestrictionId = 1, Product_Flavor = "Spanakopita", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Spiced Peach"))
												{ context.Products.Add(new Product { ProductId = 105, TypeId = 5, RestrictionId = 1, Product_Flavor = "Spiced Peach", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Spiced Praline"))
												{
																context.Products.Add(new Product { ProductId = 162, TypeId = 4, RestrictionId = 2, Product_Flavor = "Spiced Praline", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 151, TypeId = 2, RestrictionId = 2, Product_Flavor = "Spiced Praline", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 170, TypeId = 5, RestrictionId = 2, Product_Flavor = "Spiced Praline", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Spring Fling"))
												{ context.Products.Add(new Product { ProductId = 54, TypeId = 2, RestrictionId = 1, Product_Flavor = "Spring Fling", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Strawberries & Cream"))
												{ context.Products.Add(new Product { ProductId = 60, TypeId = 2, RestrictionId = 1, Product_Flavor = "Strawberries & Cream", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Strawberry"))
												{
																context.Products.Add(new Product { ProductId = 65, TypeId = 4, RestrictionId = 1, Product_Flavor = "Strawberry", Product_Description = "The sweetness of summer, vanilla donut topped with with organic strawberry glaze ", Seasonal = false });
																context.Products.Add(new Product { ProductId = 108, TypeId = 7, RestrictionId = 1, Product_Flavor = "Strawberry", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Strawberry Lemonade"))
												{
																context.Products.Add(new Product { ProductId = 89, TypeId = 3, RestrictionId = 1, Product_Flavor = "Strawberry Lemonade", Product_Description = "A lemon shortbread cookie base drizzled with homemade strawberry glaze. The perfect taste of summer.", Seasonal = false });
																context.Products.Add(new Product { ProductId = 48, TypeId = 2, RestrictionId = 1, Product_Flavor = "Strawberry Lemonade", Product_Description = "Luscious lemon cake filled with organic strawberry preserves, iced in a light lemon buttercream.", Seasonal = false });
																context.Products.Add(new Product { ProductId = 166, TypeId = 5, RestrictionId = 2, Product_Flavor = "Strawberry Lemonade", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 147, TypeId = 2, RestrictionId = 2, Product_Flavor = "Strawberry Lemonade", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 158, TypeId = 4, RestrictionId = 2, Product_Flavor = "Strawberry Lemonade", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Sugar Cookies"))
												{ context.Products.Add(new Product { ProductId = 93, TypeId = 3, RestrictionId = 1, Product_Flavor = "Sugar Cookies", Product_Description = "Buttery, sugary, yummy. Enough said. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Summer Fun"))
												{ context.Products.Add(new Product { ProductId = 53, TypeId = 2, RestrictionId = 1, Product_Flavor = "Summer Fun", Product_Description = "No Description", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Summer's End"))
												{ context.Products.Add(new Product { ProductId = 95, TypeId = 3, RestrictionId = 1, Product_Flavor = "Summer's End", Product_Description = "Lemon cookie loaded with almonds and toasted coconut", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "The Brick"))
												{ context.Products.Add(new Product { ProductId = 81, TypeId = 8, RestrictionId = 1, Product_Flavor = "The Brick", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "The Gentleman"))
												{ context.Products.Add(new Product { ProductId = 43, TypeId = 2, RestrictionId = 1, Product_Flavor = "The Gentleman", Product_Description = "Moist chocolate cake filled with our homemade raspberry pistachio preserves, iced with chocolate buttercream and semi-sweet espresso ganache.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Tiramisu"))
												{
																context.Products.Add(new Product { ProductId = 36, TypeId = 2, RestrictionId = 1, Product_Flavor = "Tiramisu", Product_Description = "Moist cake laced with espresso and Kahlua, iced in silky cream and topped with dutch cocoa and Belgian chocolate.", Seasonal = false });
																context.Products.Add(new Product { ProductId = 121, TypeId = 6, RestrictionId = 1, Product_Flavor = "Tiramisu", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Trailblazers"))
												{ context.Products.Add(new Product { ProductId = 77, TypeId = 8, RestrictionId = 1, Product_Flavor = "Trailblazers", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Triple Chocolate"))
												{ context.Products.Add(new Product { ProductId = 27, TypeId = 2, RestrictionId = 1, Product_Flavor = "Triple Chocolate", Product_Description = "BESTSELLER!! Rich chocolate cake, iced in our fudgy buttercream and layered with Belgian chocolate ganache. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Triple Chocolate Bombs"))
												{ context.Products.Add(new Product { ProductId = 97, TypeId = 3, RestrictionId = 1, Product_Flavor = "Triple Chocolate Bombs", Product_Description = "Hands down the best, most decadent chocolate cookie you will EVER taste. These won the Ghirardelli competition at the Dixie Classic Fair and feature THREE types of Belgian chocolate", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Turtle"))
												{ context.Products.Add(new Product { ProductId = 34, TypeId = 2, RestrictionId = 1, Product_Flavor = "Turtle", Product_Description = "Rich chocolate cake layered and topped with Belgian chocolate, toasted pecans, homemade caramel, and semi sweet ganache.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Vanilla"))
												{ context.Products.Add(new Product { ProductId = 83, TypeId = 8, RestrictionId = 1, Product_Flavor = "Vanilla", Product_Description = "16 grams of protein per bar, 100% gluten free and plant based. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Vanilla Almond"))
												{
																context.Products.Add(new Product { ProductId = 163, TypeId = 4, RestrictionId = 2, Product_Flavor = "Vanilla Almond", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 152, TypeId = 2, RestrictionId = 2, Product_Flavor = "Vanilla Almond", Product_Description = "No Description", Seasonal = false });
																context.Products.Add(new Product { ProductId = 171, TypeId = 5, RestrictionId = 2, Product_Flavor = "Vanilla Almond", Product_Description = "No Description", Seasonal = false });
												}
												if (!context.Products.Any(x => x.Product_Flavor == "Vanilla Caramel"))
												{ context.Products.Add(new Product { ProductId = 33, TypeId = 2, RestrictionId = 1, Product_Flavor = "Vanilla Caramel", Product_Description = "Classic vanilla cake filled and topped with our decadent homemade caramel.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Vanilla Espresso"))
												{ context.Products.Add(new Product { ProductId = 4, TypeId = 2, RestrictionId = 1, Product_Flavor = "Vanilla Espresso", Product_Description = "Vanilla cake infused with locally roasted Fortuna coffee, iced in our signature espresso buttercream and garnished with coffee beans.", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Vanilla Raspberry"))
												{ context.Products.Add(new Product { ProductId = 14, TypeId = 2, RestrictionId = 1, Product_Flavor = "Vanilla Raspberry", Product_Description = "Vanilla cake filled with organic raspberry preserves, iced in our signature vanilla buttercream and topped with fresh raspberries. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Vanilla Strawberry"))
												{ context.Products.Add(new Product { ProductId = 6, TypeId = 2, RestrictionId = 1, Product_Flavor = "Vanilla Strawberry", Product_Description = "BESTSELLER alert! Classic vanilla cake filled with organic strawberry preserves, iced with vanilla buttercream. ", Seasonal = false }); }
												if (!context.Products.Any(x => x.Product_Flavor == "Veggie Medley Lasagna"))
												{ context.Products.Add(new Product { ProductId = 127, TypeId = 9, RestrictionId = 1, Product_Flavor = "Veggie Medley Lasagna", Product_Description = "No Description", Seasonal = false }); }


												#endregion

												//Seed Test Orders
												//WIP
												#region Test Orders
												//if (!context.Orders.Any(o => o.Customer_ID == 1 || o.Customer_ID == 2 || o.Employee_ID == 1 || o.Employee_ID == 2))
												//{
												//				context.Orders.Add(new Order
												//				{
												//								ORDER_ID = 1,
												//								Customer_ID = 1,
												//								Order_Date = DateTime.Now.ToString("MM/dd/yyyy"),
												//								Order_Time = DateTimeOffset.Now,
												//								PickUp_Due_Date = DateTime.Now.AddDays(7).ToString("MM/dd/yyyy"),
												//								PickUp_Time = DateTimeOffset.Now.AddDays(7.00).ToString(),
												//								Ingredient_Substitution = context.Ingredients.FirstOrDefault().Ingredient_Name,
												//								Decoration_Comments = "Make the icing smoothed.",
												//								Additional_Comments = "",
												//								Employee_ID = 2,
												//								Order_Size_ID = 1,
												//								Finishing_ID = 57,
												//								PRODUCT = context.Products.First(p => p.TypeId == 2)
												//				});
												//				context.Orders.Add(new Order
												//				{
												//								ORDER_ID = 2,
												//								Customer_ID = 2,
												//								Order_Date = DateTime.Now.ToString("MM/dd/yyyy"),
												//								Order_Time = DateTimeOffset.Now,
												//								PickUp_Due_Date = DateTime.Now.AddDays(7).ToString("MM/dd/yyyy"),
												//								PickUp_Time = DateTimeOffset.Now.AddDays(7.00).ToString(),
												//								Ingredient_Substitution = context.Ingredients.FirstOrDefault().Ingredient_Name,
												//								Decoration_Comments = "",
												//								Additional_Comments = "Pre-cut half of the cake, 6 slices",
												//								Employee_ID = 1,
												//								Order_Size_ID = 2,
												//								Finishing_ID = 38,
												//								PRODUCT = context.Products.First(p => p.TypeId == 2)
												//				});
												//}
												#endregion
								}
				}
}