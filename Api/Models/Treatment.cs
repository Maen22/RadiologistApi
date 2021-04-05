using System;

namespace Api.Models
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public string UserId { get; set; }
        public decimal TreatmentCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TreatmentImageUrl { get; set; }
        public string TreatmentImageName { get; set; }
        
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int TreatmentTypeId { get; set; }
        public virtual TreatmentType TreatmentType { get; set; }
    }
}