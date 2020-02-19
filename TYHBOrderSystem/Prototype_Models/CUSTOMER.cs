namespace TYHBOrderSystem.Prototype_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMERS")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            ORDER_HISTORY = new HashSet<ORDER_HISTORY>();
            ORDERS = new HashSet<ORDER>();
        }

        [Required]
        [StringLength(20)]
        public string Customer_First_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Last_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Contact_Number { get; set; }

        [StringLength(15)]
        public string Alternate_Contact_Number { get; set; }

        [StringLength(100)]
        public string Allergy_Desctiption { get; set; }

        [StringLength(150)]
        public string Email_Address { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_HISTORY> ORDER_HISTORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}
