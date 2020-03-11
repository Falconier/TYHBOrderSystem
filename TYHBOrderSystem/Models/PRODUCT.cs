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
												ORDERS = new HashSet<ORDER>();
												WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
								}

								public int ProductId { get; set; }

								public int TypeId { get; set; }

								public int RestrictionId { get; set; }

        public string Product_Flavor { get; set; }

        public string Product_Description { get; set; }

								public virtual ProductType Type { get; set; }

								public virtual DietaryRestriction DietaryRestriction { get; set; }

        public virtual ICollection<ORDER> ORDERS { get; set; }

        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
