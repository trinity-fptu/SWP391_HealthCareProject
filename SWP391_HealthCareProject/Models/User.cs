using System.ComponentModel.DataAnnotations;

namespace SWP391_HealthCareProject.Models
{
    public partial class User
    {
        public User()
        {
            HospitalRedCrossAdmins = new HashSet<HospitalRedCrossAdmin>();
            Volunteers = new HashSet<Volunteer>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;
        public int Role { get; set; }
        public string? Avatar { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<HospitalRedCrossAdmin> HospitalRedCrossAdmins { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}