namespace TYHBOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_SIZES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER_SIZES()
        {
            ORDERS = new HashSet<ORDER>();
        }

        //PK
        public int Order_Size_ID { get; set; }

        /*Comment:Seems to be working as product ID_type "FK" Current Database == 'Order_Size_Type'*/
        public virtual string Product_Type_ID { get; set; }

       //Inch of cake, Count of cupcakes, etc. (Sheet cake is the only one 'size' 18x12, moving to 'Product 
        public int Order_Size { get; set; }

        //Number of layers within Cake Types, Sheet Cake 
        public int Number_Of_Layers { get; set; }


    }
}
