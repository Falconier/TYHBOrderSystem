namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCT_FINISHINGS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT_FINISHINGS()
        {
            ORDERS = new HashSet<ORDER>();
            WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
        }

        [Key]
        public int Finishing_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Finish_Type { get; set; }

        [StringLength(150)]
        public string Finishing_Flavor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
