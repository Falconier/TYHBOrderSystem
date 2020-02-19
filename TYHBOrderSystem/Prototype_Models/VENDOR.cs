namespace TYHBOrderSystem.Prototype_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENDORS")]
    public partial class VENDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENDOR()
        {
            INGREDIENTS = new HashSet<INGREDIENT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vendor_ID { get; set; }

        [Required]
        [StringLength(35)]
        public string Vendor_Name { get; set; }

        [StringLength(100)]
        public string Street_Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string Vendor_State { get; set; }

        [StringLength(10)]
        public string Postal_Code { get; set; }

        [StringLength(15)]
        public string Contact_Number { get; set; }

        [StringLength(20)]
        public string Contact_First_Name { get; set; }

        [StringLength(50)]
        public string Contact_Last_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGREDIENT> INGREDIENTS { get; set; }
    }
}
