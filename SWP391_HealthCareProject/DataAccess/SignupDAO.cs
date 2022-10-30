using SWP391_HealthCareProject.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SWP391_HealthCareProject.DataAccess
{
    public class SignupDAO
    {
        public static bool Register(User user)
        {
            using var db = new BloodDonorContext();
            user.CreatedDate = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public static bool IsUserExist(string username)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public static bool CheckEmailPattern(string email)
        {
            try
            {
                MailAddress checkMailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool CheckPasswordPattern(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(password);
        }

        //Check email exist
        public static bool IsEmailExist(string email)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
