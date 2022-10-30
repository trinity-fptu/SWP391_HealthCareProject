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

        public static void CreateHRAdmin(User user, string hrAddress, string hrPhone)
        {
            using var db = new BloodDonorContext();
            HospitalRedCross hr = HospitalRedCrossDAO.GetHRByAddress(hrAddress);
            HospitalRedCrossAdmin hrAdmin = new HospitalRedCrossAdmin();
            hrAdmin.UserId = user.UserId;
            hrAdmin.Rhid = hr.Rhid;
            hrAdmin.FirstName = "Unimplement";
            hrAdmin.LastName = "Unimplement";
            hrAdmin.License = "Unimplement";
            db.HospitalRedCrossAdmins.Add(hrAdmin);
            db.SaveChanges();
        }
    }
}