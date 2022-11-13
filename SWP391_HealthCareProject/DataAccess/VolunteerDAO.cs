using Microsoft.SqlServer.Management.Smo;
using SWP391_HealthCareProject.Models;
using System.Data.Entity;
using User = SWP391_HealthCareProject.Models.User;

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


        public static List<User> getAllUser()
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Users
                      select item).ToList();
            return us;
        }

        public List<Volunteer> getAllVolunteer()
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Volunteers
                      select item).ToList();
            return us;
        }

        public User getUserById(int id)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.Find(id);
            return user;
        }

        public void updateUser(User user)
        {
            using var db = new BloodDonorContext();
            try
            {
                User _user = getUserById(user.UserId);
                if (_user != null)
                {
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateVolunteer(Volunteer vol)
        {
            using var db = new BloodDonorContext();
            try
            {
                if (vol != null)
                {
                    db.Volunteers.Update(vol);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Volunteer does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static User? GetUserLastRecord()
        {
            using var db = new BloodDonorContext();
            var user = db.Users.OrderByDescending(x => x.UserId).FirstOrDefault();
            return user;
        }
    }
}