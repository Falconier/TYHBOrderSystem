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
								}
				}
}