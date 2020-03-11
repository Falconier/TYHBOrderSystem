namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WEDDING_TASTING_BOX_ORDERS
    {
        public WEDDING_TASTING_BOX_ORDERS()
        {
            WTBO_HISTORY = new HashSet<WTBO_HISTORY>();
        }

        public int WTBO_ID { get; set; }

        public string Event_Date { get; set; }

        public string Bride_First_Name { get; set; }

        public string Bride_Last_Name { get; set; }

        public string Bride_Contact_Number { get; set; }

        public string Bride_Email_Address { get; set; }

        public string Groom_First_name { get; set; }

        public string Groom_Last_Name { get; set; }

        public string Groom_Contact_Number { get; set; }

        public string Groom_Email_Address { get; set; }

        public string Wedding_Coordinator__First_Name { get; set; }

        public string Wedding_Coordinator_Last_Name { get; set; }

        public string Wedding_Coordinator_Contact { get; set; }

        public string Wedding_Coordinator_Email_Address { get; set; }

        public string Venue_Name { get; set; }

        public string Venue_Street_Address { get; set; }

        public string Venue_City { get; set; }

        public string Delivery_Option_Y_N_ { get; set; }

        public string Estimated_Number_Of_Guests { get; set; }

        public string Catering_Request_Y_N_ { get; set; }

        public byte[] Wedding_Cake_Description { get; set; }

        public string Decorations_Comments { get; set; }

        public string Cupcake_Flavor_Option_ONE { get; set; }

        public string Cupcake_Flavor_Option_TWO { get; set; }

        public string Cupcake_Flavor_Option_THREE { get; set; }

        public string Allergy_Description { get; set; }

        public string Ingredient_Substitution_Comments { get; set; }

        public string Dessert_Bar_Y_N_ { get; set; }

        public string Dessert_Bar_Comments { get; set; }

        public string Order_Due_Date { get; set; }

        public string Date_Paid { get; set; }

        public string Date_Pick_UP { get; set; }

        public string Employee_Initials { get; set; }

        public int? Ingredient_ID { get; set; }

        public int? Product_ID { get; set; }

        public int? Finishing_ID { get; set; }

        public int? Employee_ID { get; set; }

        public virtual Employees EMPLOYEE { get; set; }

        public virtual Ingredient INGREDIENT { get; set; }

        public virtual ProductFinishings PRODUCT_FINISHINGS { get; set; }

        public virtual Product PRODUCT { get; set; }

        public virtual ICollection<WTBO_HISTORY> WTBO_HISTORY { get; set; }
    }
}
