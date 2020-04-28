using Ember_Medical_Service.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Models
{
    public class CreateAppointmentVM
    {   
       

        [Required]
        public String PatientID { get; set; }

        [Required]
        public PatientInfoVM Patient { get; set; }

        [Required]
        public String PhysicianID { get; set; }

        [Required]
        public StaffInfoVM Physician { get; set; }

        [Required]
        public String CreatedByID { get; set; }

        [Required]
        public StaffInfoVM CreatedBy { get; set; }

        [Required]
        public DateTime ApptDate { get; set; }

        [Required]
        public DateTime ApptTime { get; set; }
        public String Comment { get; set; }

        IEnumerable<SelectListItem> PhysicianList { get; set; }


    }

    public class ListOfAppointmentVM
    {
        public int ID { get; set; }

        [Display(Name = "Patient Name")]
        public String PatientID { get; set; }

        public PatientInfoVM Patient { get; set; }

        [Display(Name = "Doctor Name")]
        public String PhysicianID { get; set; }

        public StaffInfoVM Physician { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime ApptDate { get; set; }

        [Display(Name = "Appointment Time")]
        public DateTime ApptTime { get; set; }
        public String Comment { get; set; }
    }
}
