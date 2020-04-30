using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }

        public string Title { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required]
        public string UserName { get; set; }


        public string Position { get; set; }
    }
}
