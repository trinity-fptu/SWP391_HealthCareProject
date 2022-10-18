namespace SWP391_HealthCareProject.Models.Entity
{
    public class Representative
    {
        public int RepresentativeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Lincense { get; set; }
        public int UserId { get; set; }
        public int HospitalRedCrossId { get; set; }
    }
}
