using EmberMedicalServicePortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Data
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public string Gender { get; set; }
        public int Phone { get; set; }


        
        public string Address { get; set; }

        public DateTime DateJoined { get; set; }
        

    }
}
