namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMERS")]
    public partial class CUSTOMER
    {
        public CUSTOMER()
        {
            ORDERS = new HashSet<Order>();
        }

        public int Customer_ID { get; set; }

        public string Customer_First_Name { get; set; }

        public string Customer_Last_Name { get; set; }

        public string Contact_Number { get; set; }

        public string Alternate_Contact_Number { get; set; }

        public string Allergy_Desctiption { get; set; }

        public string Email_Address { get; set; }

        public virtual ICollection<Order> ORDERS { get; set; }
    }
}
