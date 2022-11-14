using SWP391_HealthCareProject.Controllers;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HospitalRedCrossAdminDAO
    {


        public static HospitalRedCrossAdmin? GetHRAdrByUserId(int userId)
        {
            using var db = new BloodDonorContext();
            var HRAdmin = db.HospitalRedCrossAdmins.FirstOrDefault(x => x.UserId == userId);
            return HRAdmin;
        }

        public static void CreateHRAdmin(HospitalRedCrossAdmin hrAdmin)
        {
            using var db = new BloodDonorContext();
            db.HospitalRedCrossAdmins.Add(hrAdmin);
            db.SaveChanges();
        }

      
    }
}