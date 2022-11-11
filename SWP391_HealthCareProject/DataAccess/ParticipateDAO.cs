using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class ParticipateDAO
    {
        public static void AddParticipate(Participate participate)
        {
            using var db = new BloodDonorContext();
            db.Participates.Add(participate);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
