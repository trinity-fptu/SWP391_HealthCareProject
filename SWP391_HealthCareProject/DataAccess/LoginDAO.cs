using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using SWP391_HealthCareProject.Models;

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

        
    }
}