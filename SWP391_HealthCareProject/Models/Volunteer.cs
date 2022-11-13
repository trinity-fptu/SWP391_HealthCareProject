using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; } 
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string? BloodType { get; set; }
        public int Attended { get; set; }
        public string? IdCardNumber { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public override string? ToString() => $"{VolunteerId} {LastName} {FirstName} {Address} {City} {Phone} {Dob} {Gender} {BloodType} {Attended} {IdCardNumber} {UserId}";
    }
}
