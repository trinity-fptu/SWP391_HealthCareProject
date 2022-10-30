using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class AdminDAO
    {
        List<User> users = new List<User>();

        //CRUD function
        public List<User> getAllUser()
        {
            using var db = new BloodDonorContext();
            users = db.Users.ToList();
            return users;
        }

        public User getUserById(int id)
        {
            using var db = new BloodDonorContext();
            var user = db.Users.Find(id);
            return user;
        }

        public bool addUser(User user)
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

        public bool updateUser(User user)
        {
            using var db = new BloodDonorContext();
            if (db.Users.Find(user.UserName) == null)
            {
                return false;
            }
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

        public bool deleteUser(User user)
        {
            using var db = new BloodDonorContext();
            if (db.Users.Find(user.UserName) == null)
            {
                return false;
            }
            db.Users.Remove(user);
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
