namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEES")]
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            ORDERS = new HashSet<ORDER>();
            WEDDING_TASTING_BOX_ORDERS = new HashSet<WEDDING_TASTING_BOX_ORDERS>();
        }

        public int Employee_ID { get; set; }

        public string Emp_First_Name { get; set; }

        public string Emp_Last_Name { get; set; }

        public string Emp_Initials { get; set; }

        public virtual ICollection<ORDER> ORDERS { get; set; }

        public virtual ICollection<WEDDING_TASTING_BOX_ORDERS> WEDDING_TASTING_BOX_ORDERS { get; set; }
    }
}
