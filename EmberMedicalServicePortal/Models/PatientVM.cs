using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Models
{

    public class PatientInfoVM
    {

        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }

        IEnumerable<SelectListItem> GenderOption { get; set; }




    }
}
