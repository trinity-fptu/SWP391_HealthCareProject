using SWP391_HealthCareProject.Models;
using System.Text.RegularExpressions;

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

        public static bool CheckPasswordPattern(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(password);
        }

    }
}
