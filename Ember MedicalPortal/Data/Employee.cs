using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_MedicalPortal.Data
{
    public class Employee :IdentityUser
    {

        public String Title { get; set; }
        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Position { get; set; }



    }
}
