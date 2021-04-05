using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.ViewModels
{
    public class TreatmentViewModel
    {
        public int TreatmentId { get; set; }
        public string UserId { get; set; }
        public decimal TreatmentCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TreatmentImageUrl { get; set; }
        public string TreatmentImageName { get; set; }
        public int PatientId { get; set; }
        public string TreatmentName { get; set; }
        public int TreatmentTypeId { get; set; }
        public virtual TreatmentType TreatmentType { get; set; }
    }
}