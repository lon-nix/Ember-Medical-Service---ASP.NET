using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Data
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }

        public DateTime ApptDate { get; set; }
        public DateTime ApptTime { get; set; }
        public String Comment { get; set; }
    }
}
