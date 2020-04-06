namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Order
    {
        //PK
        [Key]
        public int ORDER_ID { get; set; }

        //FK
        public int? Customer_ID { get; set; }

        //OrderDate
        public string Order_Date { get; set; }

        //Time (AM/PM)of pickup of Order
        //Needs repair - JB
        public DateTimeOffset? Order_Time { get; set; }

        //Date of Pickup Order
        public string PickUp_Due_Date { get; set; }

        //Time AM/PM of pickup Time
        public string PickUp_Time { get; set; }

        //FK (FROM Products, Also on Order_Size)
        //public virtual int Product_Type_ID { get; set; }


        //Keeping for now in case of use of 'ingredients' for population'
        public string Ingredient_Substitution { get; set; }

        //Per Jacob, for report views to make easier
        public string Decoration_Comments { get; set; }

        //Comments
        public string Additional_Comments { get; set; }

        public int Employee_ID { get; set; }

        public int? Order_Size_ID { get; set; }


        //Note to 'Self' this is need to connect to product finishing table
        public int? Finishing_ID { get; set; }

        public int? Ingredient_ID { get; set; }

        public virtual Customer CUSTOMER { get; set; }

        public virtual Employees EMPLOYEE { get; set; }

        public virtual Ingredient INGREDIENT { get; set; }

        public virtual OrderSizes ORDER_SIZES { get; set; }

        public virtual ProductFinishings PRODUCT_FINISHINGS { get; set; }

        public virtual Product PRODUCT { get; set; }

        //Product Category Drop Down List Attempt

        
    }
}
