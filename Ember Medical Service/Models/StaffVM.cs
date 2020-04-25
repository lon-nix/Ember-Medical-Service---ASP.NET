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
    public class CreateStaffVM 
    {
       

        public String Title { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Gender { get; set; }

        public int PositionID { get; set; }
        public ListOfPositionsVM Position { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]

        public String Address { get; set; }

        IEnumerable<SelectListItem> Positions { get; set; }



    }

    public class StaffInfoVM
    {

        public String Id { get; set; }

        public String Title { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        public String Gender { get; set; }

        public int PositionID { get; set; }
        public ListOfPositionsVM Position { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]

        public String Address { get; set; }



    }
}
