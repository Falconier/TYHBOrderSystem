namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTS")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ORDERS = new HashSet<ORDER>();
            WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
        }

        [Key]
        public int Product_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Product_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Flavor { get; set; }

        public string Product_Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
