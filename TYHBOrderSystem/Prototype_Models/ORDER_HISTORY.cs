namespace TYHBOrderSystem.Prototype_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_HISTORY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_History_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID { get; set; }

        [StringLength(15)]
        public string Order_Date { get; set; }

        [MaxLength(1)]
        public byte[] Decoration_Comments { get; set; }

        [StringLength(100)]
        public string Allergy_Description { get; set; }

        [StringLength(250)]
        public string Additional_Comments { get; set; }

        [StringLength(15)]
        public string Date_Archived { get; set; }

        [Required]
        [StringLength(15)]
        public string Product_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Flavor { get; set; }

        [StringLength(50)]
        public string Finishing_Comments { get; set; }

        [StringLength(50)]
        public string Ingredient_Substitution { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDER_ID { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
