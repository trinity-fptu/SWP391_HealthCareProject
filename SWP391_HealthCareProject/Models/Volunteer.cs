using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string BloodType { get; set; } = null!;
        public int Attended { get; set; }
        public string IdCardNumber { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
