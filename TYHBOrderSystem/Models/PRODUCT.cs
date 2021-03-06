namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

				public partial class Product
				{
								public Product()
								{
												ORDERS = new HashSet<Order>();
												WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
								}

								[Key]
								public int ProductId { get; set; }

								public int TypeId { get; set; }

								public int RestrictionId { get; set; }

        public string Product_Flavor { get; set; }

        public string Product_Description { get; set; }

								public bool Seasonal { get; set; }

								public virtual ProductType Type { get; set; }

								public virtual DietaryRestriction Restriction { get; set; }

        public virtual ICollection<Order> ORDERS { get; set; }

        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
