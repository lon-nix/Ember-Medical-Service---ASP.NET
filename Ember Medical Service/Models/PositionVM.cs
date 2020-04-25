using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Data
{
    public class CreatePositionVM
    {
        
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }

    }


    public class ListOfPositionsVM
    {

        public int ID { get; set; }

        
        public String Name { get; set; }

    }
}
