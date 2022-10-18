namespace SWP391_HealthCareProject.Models.Entity
{
    public class Campain
    {
        public int CampainId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public int NumberOfVolunteer { get; set; }
        public int Cost { get; set; }
        public int HospitalRedCrossId { get; set; }
    }
}
