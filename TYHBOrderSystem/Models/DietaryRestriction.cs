using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TYHBOrderSystem.Models
{
				public class DietaryRestriction
				{
								[Key]
								public int Id { get; set; }

								public string RestrictionName { get; set; }
				}
}