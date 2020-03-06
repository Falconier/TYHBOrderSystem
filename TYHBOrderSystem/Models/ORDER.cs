namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [Key]
        public int ORDER_ID { get; set; }

        public int? Customer_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Order_Date { get; set; }

        [Required]
        [StringLength(6)]
        public string Order_Time { get; set; }

        [Required]
        [StringLength(15)]
        public string Due_Date { get; set; }

        public int Product_ID { get; set; }

        [StringLength(50)]
        public string Allergy_Description { get; set; }

        public int? Ingredient_Substitution { get; set; }

        public byte[] Decoration_Comments { get; set; }

        public string Additional_Comments { get; set; }

        [StringLength(150)]
        public string Finishing_Comments { get; set; }

        [Required]
        [StringLength(15)]
        public string Pick_Up_Date { get; set; }

        [Required]
        [StringLength(6)]
        public string Pick_Up_Time { get; set; }

        public int Employee_ID { get; set; }

        public int? Order_Size_ID { get; set; }

        public int? Finishing_ID { get; set; }

        public int? Ingredient_ID { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual INGREDIENT INGREDIENT { get; set; }

        public virtual ORDER_SIZES ORDER_SIZES { get; set; }

        public virtual PRODUCT_FINISHINGS PRODUCT_FINISHINGS { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
