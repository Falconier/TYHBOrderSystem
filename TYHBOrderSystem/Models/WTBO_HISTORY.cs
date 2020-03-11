namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WTBO_HISTORY
    {
        public int WTBO_History_ID { get; set; }

        public int WTBO_ID { get; set; }

        public byte[] Wedding_Cake_Description { get; set; }

        public byte[] Decorations { get; set; }

        public virtual WEDDING_TASTING_BOX_ORDERS WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
