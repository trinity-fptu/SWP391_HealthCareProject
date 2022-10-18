namespace SWP391_HealthCareProject.Models.Entity
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Attendance { get; set; }
        public string City { get; set; }
        public string IdCardNumber { get; set; }
        public string UserId { get; set; }
    }
}
