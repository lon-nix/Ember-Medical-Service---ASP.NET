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
    public class CreateMedicalRecordVM
    {
        [Key]
        public int ID { get; set; }

        public String PatientID { get; set; }
        
        public PatientInfoVM Patient { get; set; }

        public String NurseID { get; set; }
     
        public StaffInfoVM Nurse { get; set; }

        public String PhysicianID { get; set; }
      
        public StaffInfoVM Physician { get; set; }
        public DateTime CreatedDate { get; set; }

        public float Weight_lb { get; set; }
        public float Height_cm { get; set; }
        public String Blood_Sugar { get; set; }
        public String Blood_Pressure { get; set; }
        public String Symptoms { get; set; }
        public String Diagnosis { get; set; }
        public String Prescription { get; set; }
        public String Comments { get; set; }

        IEnumerable<SelectListItem> PhysicianList { get; set; }

        IEnumerable<SelectListItem> NurseList { get; set; }
    }

    public class MedicalHistoryVM
    {

        public int ID { get; set; }
        public String PatientID { get; set; }

        public PatientInfoVM Patient { get; set; }

        public String NurseID { get; set; }

        public StaffInfoVM Nurse { get; set; }

        public String PhysicianID { get; set; }

        public StaffInfoVM Physician { get; set; }
        public DateTime CreatedDate { get; set; }

        public float Weight_lb { get; set; }
        public float Height_cm { get; set; }
        public String Blood_Sugar { get; set; }
        public String Blood_Pressure { get; set; }
        public String Symptoms { get; set; }
        public String Diagnosis { get; set; }
        public String Prescription { get; set; }
        public String Comments { get; set; }
    }
}
