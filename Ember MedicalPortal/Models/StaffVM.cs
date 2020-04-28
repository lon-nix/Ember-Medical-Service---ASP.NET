﻿using Ember_Medical_Service.Data;
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
    public class CreateStaffVM 
    {

        
        public String Title { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

     

             
        
        [Required]
        public String Email { get; set; }

        [Required]
        public String PhoneNumber { get; set; }

        [Required]

        public String Address { get; set; }

      


    }

    public class StaffInfoVM
    {
        
       

        public int Id { get; set; }
        public String Title { get; set; }

        [Display(Name ="First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        

        [Required]
        public String Email { get; set; }

    
        [Required]

        public String Address { get; set; }



    }
}