using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Data
{
    public class Staff : IdentityUser
    {
        public String Title { get; set; }
        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Position { get; set; }


    }
}
