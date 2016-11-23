using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.Core.DTO.Customer
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Missing First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Missing Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Missing Address 1")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Missing City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Missing State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip")]
        public string Zip { get; set; }

        public class WithRelations : CustomerDTO
        {
            public IEnumerable<CustomerEmailDTO> Emails { get; set; }
            public IEnumerable<CustomerPhoneDTO> Phones { get; set; }
        }

        public class Registration
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required, EmailAddress]
            [Display(Name = "Email address")]
            public string EmailAddress { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Telephone { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
        }
    }
}
