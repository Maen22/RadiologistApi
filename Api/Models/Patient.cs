using System;
using System.Collections;
using System.Collections.Generic;

namespace Api.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Treatment> Treatments { get; set; }
    }

    public enum Gender
    {
        FEMALE,
        MALE
    }
}