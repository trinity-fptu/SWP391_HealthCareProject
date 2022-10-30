﻿using SWP391_HealthCareProject.Models;

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
    }
}