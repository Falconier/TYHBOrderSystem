namespace TYHBOrderSystem.Prototype_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ORDER_HISTORY = new HashSet<ORDER_HISTORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDER_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Order_Date { get; set; }

        [Required]
        [StringLength(6)]
        public string Order_Time { get; set; }

        [Required]
        [StringLength(20)]
        public string Product_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Flavor { get; set; }

        [StringLength(20)]
        public string Order_Size { get; set; }

        [Required]
        [StringLength(15)]
        public string Due_Date { get; set; }

        [StringLength(50)]
        public string Allergy_Description { get; set; }

        public byte[] Decoration_Comments { get; set; }

        public string Additional_Comments { get; set; }

        [Required]
        [StringLength(15)]
        public string Pick_Up_Date { get; set; }

        [Required]
        [StringLength(6)]
        public string Pick_Up_Time { get; set; }

        [Required]
        [StringLength(3)]
        public string Employee_Initials { get; set; }

        public int? Ingredient_Substitution { get; set; }

        public int Employee_ID { get; set; }

        [StringLength(150)]
        public string Finishing_Comments { get; set; }

        public int? Order_Size_ID { get; set; }

        public int Product_ID { get; set; }

        public int? Customer_ID { get; set; }

        public int? Finishing_ID { get; set; }

        public int? Ingredients_ID { get; set; }

        public virtual CAKE_FINISHINGS CAKE_FINISHINGS { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual INGREDIENT INGREDIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_HISTORY> ORDER_HISTORY { get; set; }

        public virtual ORDER_SIZES ORDER_SIZES { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
