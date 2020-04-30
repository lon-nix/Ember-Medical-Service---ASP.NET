using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Title { get; set; }
           
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Position { get; set; }

    }
}
