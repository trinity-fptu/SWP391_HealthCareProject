using Microsoft.SqlServer.Management.Smo;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HospitalRedCrossDAO
    {
        public static HospitalRedCross? GetHRByAddress(string hrAddress)
        {
            using var db = new BloodDonorContext();
            var HR = db.HospitalRedCrosses.FirstOrDefault(x => x.Address == hrAddress);
            return HR;
        }
        public static HospitalRedCross? GetHRById(int rhId)
        {
            using var db = new BloodDonorContext();
            var HR = db.HospitalRedCrosses.FirstOrDefault(x => x.Rhid == rhId);
            return HR;
        }


        public static void UpdateHR(HospitalRedCross HR)
        {
            using var db = new BloodDonorContext();
            try
            {
                if (HR != null)
                {
                    db.HospitalRedCrosses.Update(HR);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("HR does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}