using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Data
{
    public class Patient : IdentityUser
    {


        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Gender { get; set; }


        public DateTime DateOfBirth { get; set; }

        [Required]
        public String Address { get; set; }
        
        public DateTime DateJoined { get; set; }
        public String AccessedByID { get; set; }
        [ForeignKey("AccessedByID")]
        public Staff AccessedBy { get; set; }

    }
}
