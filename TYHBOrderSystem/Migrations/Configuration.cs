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


								}
				}
}