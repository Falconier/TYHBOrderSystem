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
												//Sets Administrator (Admin)

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



												//Seed Product Types
												if (!context.ProductTypes.Any(u => u.Name == "Bread"))
												{ context.ProductTypes.Add(new ProductType { Name = "Bread" }); }
								}
    }
}
