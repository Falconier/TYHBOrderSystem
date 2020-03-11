using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TYHBOrderSystem.Models
{
				public class ProductType
				{
								public int Id { get; set; }

								public string Name { get; set; }

								public virtual ICollection<Product> Product { get; set; }
				}
}