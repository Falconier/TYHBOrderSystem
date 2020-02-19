namespace TYHBOrderSystem.Prototype_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WTBO_HISTORY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WTBO_History_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WTBO_ID { get; set; }

        public string Wedding_Cake_Description { get; set; }

        [MaxLength(1)]
        public byte[] Decorations { get; set; }

        public virtual WEDDING_TASTING_BOX_ORDERS WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
