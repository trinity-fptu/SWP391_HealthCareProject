using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SWP391_HealthCareProject.Models;
using System.Linq;

namespace SWP391_HealthCareProject.DataAccess
{
    public class LoginDAO 
    {

        public static User? Login(string username, string password)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            return user;
        }

        public static bool Register(User user)
        {
            using var db = new BloodDonorContext();
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
    }
}
