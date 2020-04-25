using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Data
{
    public class MedicalRecord
    {
        [Key]
        public int ID { get; set; }
        public String PatientID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }

        public String NurseID { get; set; }
        [ForeignKey("NurseID")]
        public Staff Nurse { get; set; }

        public String PhysicianID { get; set; }
        [ForeignKey("PhysicianID")]
        public Staff Physician { get; set; }
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
