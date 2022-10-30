namespace SWP391_HealthCareProject.Models
{
    public partial class HospitalRedCrossAdmin
    {
        public HospitalRedCrossAdmin()
        {
            Posts = new HashSet<Post>();
        }

        public int Rhaid { get; set; }
        public int UserId { get; set; }
        public int Rhid { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string License { get; set; } = null!;

        public virtual HospitalRedCross Rh { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Post> Posts { get; set; }
    }
}