namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductFinishings
    {
        public ProductFinishings()
        {
            ORDERS = new HashSet<Order>();
            WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
        }

        public int FinishingID { get; set; }

        public string FinishType { get; set; }

        public string FinishingFlavor { get; set; }

        public virtual ICollection<Order> ORDERS { get; set; }

        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
