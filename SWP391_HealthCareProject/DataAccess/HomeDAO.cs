using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HomeDAO
    {
        //Get post detail in database
        public List<Post> getPostDetail()
        {
            using (var db = new BloodDonorContext())
            {
                var post = db.Posts.ToList();
                return post;
            }
        }
    }
}
