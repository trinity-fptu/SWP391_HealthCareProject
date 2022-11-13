using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class AdminDAO
    {
        private List<User> users = new List<User>();

        //CRUD function
        public List<User> getAllUser()
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Users
                     select item).ToList();
            return us;
        }

        public User getUserById(int id)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.Find(id);
            return user;
        }

        public void addUser(User user)
        {
            using var db = new BloodDonorContext();
            try
            {
                User _user = getUserById(user.UserId);
                if(_user == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void updateUser(User user)
        {
            using var db = new BloodDonorContext();
            try
            {
                User _user = getUserById(user.UserId);
                if(_user != null)
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

        public void deleteUser(int id)
        {
            using var db = new BloodDonorContext();
            try
            {
                User user = getUserById(id);
                Volunteer volunteer = VolunteerDAO.GetVolunteerByUserId(user.UserId);
                if(user != null)
                {
                    db.Volunteers.Remove(volunteer);
                    db.Users.Remove(user);
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