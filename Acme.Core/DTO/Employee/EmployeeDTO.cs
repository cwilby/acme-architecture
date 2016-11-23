using Acme.Core.Domain.Employee;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.Core.DTO.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Could be refactored into a seperate `Address.cs` file also.
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public class WithRelations : EmployeeDTO
        {
            public IEnumerable<EmployeeEmail> Emails { get; set; }
            public IEnumerable<EmployeePhone> Phones { get; set; }
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
