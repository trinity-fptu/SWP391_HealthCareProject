using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class UserProfileModels
    {
        BloodDonorContext bloodDonorContext = new BloodDonorContext();
        public List<User> UserViewModel { get; set; }

        public List<Volunteer> VolunteerViewModel { get; set; }

        public User GetUserById(int id) => bloodDonorContext.Users.Where(x => x.UserId == id).FirstOrDefault();

        public Volunteer GetVolunteerById(int id)
        {
            return bloodDonorContext.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();
        }
    }
}
