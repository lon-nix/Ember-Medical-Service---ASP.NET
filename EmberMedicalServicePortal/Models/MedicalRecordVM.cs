using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Models
{
    public class CreateMedicalRecordVM
    {


        public int PatientID { get; set; }

        public PatientInfoVM Patient { get; set; }

       
        public DateTime CreatedDate { get; set; }

        public float Weight_lb { get; set; }
        public float Height_cm { get; set; }
        public string Blood_Sugar { get; set; }
        public string Blood_Pressure { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Comments { get; set; }
        IEnumerable<SelectListItem> PatientList { get; set; }


    }

    public class MedicalHistoryVM
    {
        public int ID { get; set; }

        [Display(Name = "Patient Name")]

        public String PatientID { get; set; }

        public PatientInfoVM Patient { get; set; }


        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Weight lbs:")]
        public float Weight_lb { get; set; }

        [Display(Name = "Height cm:")]
        public float Height_cm { get; set; }

        [Display(Name = "Blood Sugar")]
        public string Blood_Sugar { get; set; }

        [Display(Name = "Blood Pressure")]
        public string Blood_Pressure { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Comments { get; set; }
    }
}
