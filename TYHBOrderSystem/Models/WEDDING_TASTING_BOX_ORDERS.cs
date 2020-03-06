namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WEDDING_TASTING_BOX_ORDERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WEDDING_TASTING_BOX_ORDERS()
        {
            WTBO_HISTORY = new HashSet<WTBO_HISTORY>();
        }

        [Key]
        public int WTBO_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Event_Date { get; set; }

        [Required]
        [StringLength(20)]
        public string Bride_First_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Bride_Last_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Bride_Contact_Number { get; set; }

        [StringLength(100)]
        public string Bride_Email_Address { get; set; }

        [StringLength(20)]
        public string Groom_First_name { get; set; }

        [StringLength(50)]
        public string Groom_Last_Name { get; set; }

        [StringLength(15)]
        public string Groom_Contact_Number { get; set; }

        [StringLength(100)]
        public string Groom_Email_Address { get; set; }

        [StringLength(20)]
        public string Wedding_Coordinator__First_Name { get; set; }

        [StringLength(50)]
        public string Wedding_Coordinator_Last_Name { get; set; }

        [StringLength(15)]
        public string Wedding_Coordinator_Contact { get; set; }

        [StringLength(100)]
        public string Wedding_Coordinator_Email_Address { get; set; }

        [StringLength(50)]
        public string Venue_Name { get; set; }

        [StringLength(100)]
        public string Venue_Street_Address { get; set; }

        [StringLength(35)]
        public string Venue_City { get; set; }

        [StringLength(3)]
        public string Delivery_Option_Y_N_ { get; set; }

        [StringLength(4)]
        public string Estimated_Number_Of_Guests { get; set; }

        [StringLength(3)]
        public string Catering_Request_Y_N_ { get; set; }

        [MaxLength(1)]
        public byte[] Wedding_Cake_Description { get; set; }

        public string Decorations_Comments { get; set; }

        [Required]
        [StringLength(50)]
        public string Cupcake_Flavor_Option_ONE { get; set; }

        [StringLength(50)]
        public string Cupcake_Flavor_Option_TWO { get; set; }

        [StringLength(50)]
        public string Cupcake_Flavor_Option_THREE { get; set; }

        [StringLength(100)]
        public string Allergy_Description { get; set; }

        [StringLength(100)]
        public string Ingredient_Substitution_Comments { get; set; }

        [StringLength(3)]
        public string Dessert_Bar_Y_N_ { get; set; }

        [StringLength(100)]
        public string Dessert_Bar_Comments { get; set; }

        [Required]
        [StringLength(15)]
        public string Order_Due_Date { get; set; }

        [Required]
        [StringLength(15)]
        public string Date_Paid { get; set; }

        [Required]
        [StringLength(15)]
        public string Date_Pick_UP { get; set; }

        [Required]
        [StringLength(3)]
        public string Employee_Initials { get; set; }

        public int? Ingredient_ID { get; set; }

        public int? Product_ID { get; set; }

        public int? Finishing_ID { get; set; }

        public int? Employee_ID { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual INGREDIENT INGREDIENT { get; set; }

        public virtual PRODUCT_FINISHINGS PRODUCT_FINISHINGS { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WTBO_HISTORY> WTBO_HISTORY { get; set; }
    }
}
