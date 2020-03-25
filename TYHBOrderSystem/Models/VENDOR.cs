namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendor
    {
								[Key]
        public int Vendor_ID { get; set; }

        public string Vendor_Name { get; set; }

        public string Street_Address { get; set; }

        public string City { get; set; }

        public string Vendor_State { get; set; }

        public string Postal_Code { get; set; }

        public string Contact_Number { get; set; }

        public string Contact_First_Name { get; set; }

        public string Contact_Last_Name { get; set; }
    }
}
