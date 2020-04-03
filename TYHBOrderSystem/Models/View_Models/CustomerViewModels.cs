using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TYHBOrderSystem.Models.View_Models
{
    public class CustomerViewModels
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        public string PrimarymNum { get; set; }

        public string AlternativeNum { get; set; }

        public string AllergyDesc { get; set; }


    }
}