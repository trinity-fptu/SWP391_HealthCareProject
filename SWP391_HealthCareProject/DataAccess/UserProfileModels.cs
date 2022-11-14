using SWP391_HealthCareProject.Models;
using System.Text.RegularExpressions;

namespace SWP391_HealthCareProject.DataAccess
{
    public class UserProfileModels
    {
        BloodDonorContext bloodDonorContext = new BloodDonorContext();
        public List<User> UserViewModel { get; set; }


        public List<HospitalRedCrossAdmin> HRAdminViewModel { get; set; }

        public List<Volunteer> VolunteerViewModel { get; set; }

        public List<Campaign> GetAllCampaigns()=> bloodDonorContext.Campaigns.ToList();

        public Post GetPostByCampaign(int id) => bloodDonorContext.Posts.Where(x => x.CampaignId == id).FirstOrDefault();

        public List<Participate> GetParticipatesByVolunteerId(int id) => bloodDonorContext.Participates.Where(x => x.VolunteerId == id).ToList();

        public List<Campaign> GetCampignListInParticipate(int id) => bloodDonorContext.Campaigns.Where(x => x.CampaignId == id).ToList();

        public Participate GetParticipateByCampaignId(int id) => bloodDonorContext.Participates.Where(x => x.CampaignId == id).FirstOrDefault();


        public HospitalRedCrossAdmin GetRHAById(int id) => bloodDonorContext.HospitalRedCrossAdmins.Where(x => x.UserId == id).FirstOrDefault();
        public HospitalRedCross GetHRById(int id) => bloodDonorContext.HospitalRedCrosses.Where(x => x.Rhid == id).FirstOrDefault();

        public User GetUserById(int id) => bloodDonorContext.Users.Where(x => x.UserId == id).FirstOrDefault();

        public Volunteer GetVolunteerById(int id)
        {
            return bloodDonorContext.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();
        }

        public static bool CheckPasswordPattern(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(password);
        }

    }
}
