namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_SIZES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER_SIZES()
        {
            ORDERS = new HashSet<ORDER>();
        }

        [Key]
        public int Order_Size_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Order_Size_Type { get; set; }

        [Required]
        [StringLength(12)]
        public string Order_Size { get; set; }

        [StringLength(2)]
        public string Number_Of_Layers { get; set; }

        [StringLength(10)]
        public string Serving_Size { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}
