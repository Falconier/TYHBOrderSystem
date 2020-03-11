namespace TYHBOrderSystem.Models
{
				using System;
				using System.Data.Entity;
				using System.ComponentModel.DataAnnotations.Schema;
				using System.Linq;

				public partial class BakeryModels : DbContext
				{
								public BakeryModels()
												: base("name=BakeryModels")
								{
								}

								public virtual DbSet<CUSTOMER> CUSTOMERS { get; set; }
								public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
								public virtual DbSet<INGREDIENT> INGREDIENTS { get; set; }
								public virtual DbSet<ORDER_SIZES> ORDER_SIZES { get; set; }
								public virtual DbSet<ORDER> ORDERS { get; set; }
								public virtual DbSet<PRODUCT_FINISHINGS> PRODUCT_FINISHINGS { get; set; }
								public virtual DbSet<Product> PRODUCTS { get; set; }
								public virtual DbSet<VENDOR> VENDORS { get; set; }
								public virtual DbSet<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
								public virtual DbSet<WTBO_HISTORY> WTBO_HISTORY { get; set; }
								public virtual DbSet<ORDER_HISTORY> ORDER_HISTORY { get; set; }

								protected override void OnModelCreating(DbModelBuilder modelBuilder)
								{
												modelBuilder.Entity<CUSTOMER>()
																.Property(e => e.Customer_First_Name)
																.IsUnicode(false);

												modelBuilder.Entity<CUSTOMER>()
																.Property(e => e.Customer_Last_Name)
																.IsUnicode(false);

												modelBuilder.Entity<CUSTOMER>()
																.Property(e => e.Contact_Number)
																.IsUnicode(false);

												modelBuilder.Entity<CUSTOMER>()
																.Property(e => e.Alternate_Contact_Number)
																.IsUnicode(false);

												modelBuilder.Entity<CUSTOMER>()
																.Property(e => e.Allergy_Desctiption)
																.IsUnicode(false);

												modelBuilder.Entity<CUSTOMER>()
																.Property(e => e.Email_Address)
																.IsUnicode(false);

												modelBuilder.Entity<EMPLOYEE>()
																.Property(e => e.Emp_First_Name)
																.IsUnicode(false);

												modelBuilder.Entity<EMPLOYEE>()
																.Property(e => e.Emp_Last_Name)
																.IsUnicode(false);

												modelBuilder.Entity<EMPLOYEE>()
																.Property(e => e.Emp_Initials)
																.IsUnicode(false);

												modelBuilder.Entity<EMPLOYEE>()
																.HasMany(e => e.ORDERS)
																.WithRequired(e => e.EMPLOYEE)
																.WillCascadeOnDelete(false);

												modelBuilder.Entity<INGREDIENT>()
																.Property(e => e.Ingredient_Type)
																.IsUnicode(false);

												modelBuilder.Entity<INGREDIENT>()
																.Property(e => e.Ingredient_Name)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_SIZES>()
																.Property(e => e.Order_Size_Type)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_SIZES>()
																.Property(e => e.Order_Size)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_SIZES>()
																.Property(e => e.Number_Of_Layers)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_SIZES>()
																.Property(e => e.Serving_Size)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Order_Date)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Order_Time)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Due_Date)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Allergy_Description)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Additional_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Finishing_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Pick_Up_Date)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER>()
																.Property(e => e.Pick_Up_Time)
																.IsUnicode(false);

												modelBuilder.Entity<PRODUCT_FINISHINGS>()
																.Property(e => e.Finish_Type)
																.IsUnicode(false);

												modelBuilder.Entity<PRODUCT_FINISHINGS>()
																.Property(e => e.Finishing_Flavor)
																.IsUnicode(false);

												modelBuilder.Entity<Product>()
																.Property(e => e.Product_Type)
																.IsUnicode(false);

												modelBuilder.Entity<Product>()
																.Property(e => e.Product_Flavor)
																.IsUnicode(false);

												modelBuilder.Entity<Product>()
																.Property(e => e.Product_Description)
																.IsUnicode(false);

												modelBuilder.Entity<Product>()
																.HasMany(e => e.ORDERS)
																.WithRequired(e => e.PRODUCT)
																.WillCascadeOnDelete(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Vendor_Name)
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Street_Address)
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.City)
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Vendor_State)
																.IsFixedLength()
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Postal_Code)
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Contact_Number)
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Contact_First_Name)
																.IsUnicode(false);

												modelBuilder.Entity<VENDOR>()
																.Property(e => e.Contact_Last_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Event_Date)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Bride_First_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Bride_Last_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Bride_Contact_Number)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Bride_Email_Address)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Groom_First_name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Groom_Last_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Groom_Contact_Number)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Groom_Email_Address)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Wedding_Coordinator__First_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Wedding_Coordinator_Last_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Wedding_Coordinator_Contact)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Wedding_Coordinator_Email_Address)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Venue_Name)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Venue_Street_Address)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Venue_City)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Delivery_Option_Y_N_)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Estimated_Number_Of_Guests)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Catering_Request_Y_N_)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Decorations_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Cupcake_Flavor_Option_ONE)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Cupcake_Flavor_Option_TWO)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Cupcake_Flavor_Option_THREE)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Allergy_Description)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Ingredient_Substitution_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Dessert_Bar_Y_N_)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Dessert_Bar_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Order_Due_Date)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Date_Paid)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Date_Pick_UP)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.Property(e => e.Employee_Initials)
																.IsUnicode(false);

												modelBuilder.Entity<WEDDING_TASTING_BOX_ORDERS>()
																.HasMany(e => e.WTBO_HISTORY)
																.WithRequired(e => e.WEDDING_TASTING_BOX_ORDERS)
																.WillCascadeOnDelete(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Order_Date)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Date_Archived)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Allergy_Description)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Additional_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Product_Type)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Product_Flavor)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Finishing_Comments)
																.IsUnicode(false);

												modelBuilder.Entity<ORDER_HISTORY>()
																.Property(e => e.Ingredient_Substitution)
																.IsUnicode(false);
								}
				}
}
