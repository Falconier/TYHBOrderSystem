namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INGREDIENTS")]
    public partial class INGREDIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INGREDIENT()
        {
            ORDERS = new HashSet<ORDER>();
            WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
        }

        public int Ingredient_ID { get; set; }

        public string Ingredient_Type { get; set; }

        public string Ingredient_Name { get; set; }

        public int? Vendor_ID { get; set; }

        public virtual ICollection<ORDER> ORDERS { get; set; }

        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
