using Ember_Medical_Service.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Models
{
    public class CreatePatientVM 
    {
        

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Gender { get; set; }


        public DateTime DateOfBirth { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        public String PhoneNumber { get; set; }

        public String Email { get; set; }

        [Required]
        public String UserName { get; set; }

        public DateTime DateJoined { get; set; }
        public String AccessedByID { get; set; }
        public StaffInfoVM AccessedBy { get; set; }

        IEnumerable <SelectListItem> Staffs { get; set; }

    }

    public class PatientInfoVM
    {

        
        public String Id { get; set; }

        public String FirstName { get; set; }

        
        public String LastName { get; set; }

        public String Gender { get; set; }


        public DateTime DateOfBirth { get; set; }

        
        public String Address { get; set; }

        
        public String PhoneNumber { get; set; }

        public String Email { get; set; }

        [Required]
        public String UserName { get; set; }

        public DateTime DateJoined { get; set; }
        public String AccessedByID { get; set; }
        public StaffInfoVM AccessedBy { get; set; }


    }
}
