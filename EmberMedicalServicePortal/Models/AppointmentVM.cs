using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Models
{
    public class CreateAppointmentVM
    {


        [Required]
        public int PatientID { get; set; }

        [Required]
        public PatientInfoVM Patient { get; set; }

        [Required]
        public DateTime ApptDate { get; set; }

        [Required]
        public DateTime ApptTime { get; set; }
        public String Comment { get; set; }

        IEnumerable<SelectListItem> PatientList { get; set; }


    }

    public class ListOfAppointmentVM
    {
        public int ID { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientID { get; set; }

        public PatientInfoVM Patient { get; set; }     

        [Display(Name = "Appointment Date")]
        public DateTime ApptDate { get; set; }

        [Display(Name = "Appointment Time")]
        public DateTime ApptTime { get; set; }
        public string Comment { get; set; }
    }
}
