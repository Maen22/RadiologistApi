using System.Collections;
using System;

namespace Api.Models.ViewModels
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalTreatmentCost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}