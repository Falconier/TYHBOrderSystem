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

												//Sets Owners (Owner)
												if (!context.Roles.Any(r => r.Name == "Owner"))
												{
																roleManager.Create(new IdentityRole { Name = "Owner" });
												}

												if (!context.Users.Any(u => u.Email == "Owner@email.com"))
												{
																userManager.Create(new ApplicationUser { UserName = "owner@email.com", Email = "owner@email.com", FirstName = "Testing", LastName = "Owner" }, "password");
												}

												var userId2 = userManager.FindByEmail("Owner@email.com").Id;
												userManager.AddToRole(userId, "Owner");

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

												//Seed Ingredients
												#region Ingredients Type Seeds

												//Ingredient_Type
												if (!context.Ingredients.Any(x => x.Ingredient_Type == "Sugar"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Type == "Flour"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Type = "Flour" }); }

												//Ingredient_Name
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Granulated Sugar"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Granulated Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Honey"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Honey" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Agave"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Agave" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Xylitol"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Xylitol" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Swerre"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Swerre" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Sugar Free"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Sugar Free" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Organic Sugar"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Organic Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Tapiocca Powdered Sugar"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Tapiocca Powdered Sugar" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Coconut"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Coconut" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "MonkFruit"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "MonkFruit" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Almond Flour"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Almond Flour" }); }
												if (!context.Ingredients.Any(x => x.Ingredient_Name == "Brown Rice Flour"))
												{ context.Ingredients.Add(new Ingredient { Ingredient_Name = "Brown Rice Flour" }); }

												#endregion

												//Seed OrderSizes Types
												#region OrderSizes Type Seeds

												//Order_Size
												if (!context.OrderSizes.Any(x => x.Order_Size == 6))
												{ context.OrderSizes.Add(new OrderSizes { Order_Size = 6 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size == 8))
												{ context.OrderSizes.Add(new OrderSizes { Order_Size = 8 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size == 9))
												{ context.OrderSizes.Add(new OrderSizes { Order_Size = 9 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size == 10))
												{ context.OrderSizes.Add(new OrderSizes { Order_Size = 10 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size == 12))
												{ context.OrderSizes.Add(new OrderSizes { Order_Size = 12 }); }
												if (!context.OrderSizes.Any(x => x.Order_Size == 1812))
												{ context.OrderSizes.Add(new OrderSizes { Order_Size = 1812 }); }

												//Number_Of_Layers
												if (!context.OrderSizes.Any(x => x.Number_Of_Layers == 2))
												{ context.OrderSizes.Add(new OrderSizes { Number_Of_Layers = 2 }); }
												if (!context.OrderSizes.Any(x => x.Number_Of_Layers == 3))
												{ context.OrderSizes.Add(new OrderSizes { Number_Of_Layers = 3 }); }

												#endregion

												//Seed Product Types
												#region Product Type Seeds
												if (!context.ProductTypes.Any(u => u.Name == "Bread"))
												{ context.ProductTypes.Add(new ProductType { Name = "Bread" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Cake"))
												{ context.ProductTypes.Add(new ProductType { Name = "Cake" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Cookie"))
												{ context.ProductTypes.Add(new ProductType { Name = "Cookie" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Doughnut"))
												{ context.ProductTypes.Add(new ProductType { Name = "Doughnut" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Muffin"))
												{ context.ProductTypes.Add(new ProductType { Name = "Muffin" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Other Sweet"))
												{ context.ProductTypes.Add(new ProductType { Name = "Other Sweet" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Pie"))
												{ context.ProductTypes.Add(new ProductType { Name = "Pie" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Protien Bar"))
												{ context.ProductTypes.Add(new ProductType { Name = "Protien Bar" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Savory Item"))
												{ context.ProductTypes.Add(new ProductType { Name = "Savory Item" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Sheet Cake"))
												{ context.ProductTypes.Add(new ProductType { Name = "Sheet Cake" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Cupcake"))
												{ context.ProductTypes.Add(new ProductType { Name = "Cupcake" }); }

												if (!context.ProductTypes.Any(u => u.Name == "Buns"))
												{ context.ProductTypes.Add(new ProductType { Name = "Buns" }); }
												#endregion

												//Seed Dietary Restrictions
												#region Dietary Restrictions Seeds
												if (!context.DietaryRestrictions.Any(u => u.RestrictionName == "Generic"))
												{ context.DietaryRestrictions.Add(new DietaryRestriction { RestrictionName = "Generic" }); }

												if (!context.DietaryRestrictions.Any(u => u.RestrictionName == "Keto"))
												{ context.DietaryRestrictions.Add(new DietaryRestriction { RestrictionName = "Keto" }); }

												if (!context.DietaryRestrictions.Any(u => u.RestrictionName == "Paleo"))
												{ context.DietaryRestrictions.Add(new DietaryRestriction { RestrictionName = "Paleo" }); }
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

												if (!context.ProductFinishings.Any(u => u.FinishingFlavor == "Carrots"))
												{ context.ProductFinishings.Add(new ProductFinishings { FinishingFlavor = "Carrots", FinishTypeId = 1 }); }

												#endregion
								}
				}
}