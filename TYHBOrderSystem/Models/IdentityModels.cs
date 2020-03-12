using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TYHBOrderSystem.Models
{
				// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
				public class ApplicationUser : IdentityUser
				{

								public string FirstName { get; set; }

								public string LastName { get; set; }

								public string FullName { get; set; }

								public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
								{
												// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
												var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
												// Add custom user claims here
												return userIdentity;
								}
				}

				public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
				{
								public ApplicationDbContext()
												: base("TYH_Bakery", throwIfV1Schema: false)
								{
								}

								public static ApplicationDbContext Create()
								{
												return new ApplicationDbContext();
								}

								public DbSet<Customer> Customers { get; set; }

								public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }

								public DbSet<Employees> Employees { get; set; }

								public DbSet<FinishingsType> FinishingsTypes { get; set; }

								public DbSet<Ingredient> Ingredients { get; set; }

								public DbSet<Order> Orders { get; set; }

								public DbSet<OrderSizes> OrderSizes { get; set; }

								public DbSet<Product> Products { get; set; }

								public DbSet<ProductFinishings> ProductFinishings { get; set; }

								public DbSet<ProductType> ProductTypes { get; set; }

								public DbSet<Vendor> Vendors { get; set; }

								public DbSet<WEDDING_TASTING_BOX_ORDERS> WeddingOrders { get; set; }

				}
}