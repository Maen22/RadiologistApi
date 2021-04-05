using System.Collections;
using System.Collections.Generic;

namespace Api.Models
{
    public class TreatmentType
    {
        public int TreatmentTypeId { get; set; }
        public string Name { get; set; }
        public decimal DefaultCost { get; set; }
        public string UserId { get; set; }


        public IEnumerable<Treatment> Treatments { get; set; }
        
    }
}

