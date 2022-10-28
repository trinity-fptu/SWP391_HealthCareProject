using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class VolunteerDAO
    {
        public static Volunteer? GetVolunteerByUserId(int userId)
        {
            using var db = new BloodDonorContext();
            var volunteer = db.Volunteers.FirstOrDefault(x => x.UserId == userId);
            return volunteer;
        }
    }
}
