using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class LoginDAO 
    {
        public static User? Login(string username, string password)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.Find(username);
            if (user != null && user.Password.Equals(password))
            {
                return user;
            }
            return null;
        }

        public static bool Register(User user)
        {
            using var db = new BloodDonorContext();
            if (db.Users.Find(user.UserName) != null)
            {
                return false;
            }
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
    }
}
