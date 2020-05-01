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

        [Required(ErrorMessage ="Phone Number is Required")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Not a valid phone number")]
        public string PrimarymNum { get; set; }

        
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Not a valid phone number")]
        public string AlternativeNum { get; set; }

        [Required(ErrorMessage ="Email Address is required")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }

        public string AllergyDesc { get; set; }


    }
}