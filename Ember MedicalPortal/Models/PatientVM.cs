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
        public String Phone { get; set; }

        public String Email { get; set; }

        [Required]
        public String UserName { get; set; }

        
        public String AccessedByID { get; set; }
        public StaffInfoVM AccessedBy { get; set; }

        public IEnumerable <SelectListItem> Staffs { get; set; }

    }

    public class PatientInfoVM
    {

        public int ID { get; set; }

        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Date Of Birth")]

        public DateTime DateOfBirth { get; set; }
       
        public String Address { get; set; }

        [Display(Name = "Phone number")]
        public String Phone { get; set; }

        public String Email { get; set; }
                  
        public String AccessedByID { get; set; }
        public StaffInfoVM AccessedBy { get; set; }


    }
}
