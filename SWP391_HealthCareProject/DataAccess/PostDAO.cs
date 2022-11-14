using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class PostDAO
    {
        public static Post? GetLastRecord()
        {
            using var db = new BloodDonorContext();
            var post = db.Posts.OrderByDescending(p => p.PostId).FirstOrDefault();
            return post;
        }
        public static Post GetPostById(int postId)
        {
            using var db = new BloodDonorContext();
            var post = db.Posts.Find(postId);
            return post;
        }
        public static void DeletePostById(int postId)
        {
            using var db = new BloodDonorContext();
            var post = GetPostById(postId);
            /*if (post.Img != null)
            {
                string removingImg = post.Img;
                File.Delete(removingImg);
            }*/
            
            try
            {
                if (post != null)
                    db.Posts.Remove(post);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void UpdatePostById(int postId)
        {
            using var db = new BloodDonorContext();
            Post post = GetPostById(postId);
            Console.WriteLine($"{post.PostId} {post.Rhaid} {post.Img} {post.Title} {post.Description} {post.CampaignId}");
            try
            {
                if(post != null)
                {
                    db.Posts.Update(post);
                    int a=  db.SaveChanges();
                    Console.WriteLine(a);
                }
                  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<Post> GetPostsByRHaid(int RHaid)
        {
            using var db = new BloodDonorContext();
            var posts = db.Posts.Where(p => p.Rhaid == RHaid).ToList();
            return posts;
        }

        public static void AddPost(Post post)
        {
            using var db = new BloodDonorContext();
            db.Posts.Add(post);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Post> getPostById(int postID)
        {
            using var db = new BloodDonorContext() ;
            var us = (from item in db.Posts
                      where item.PostId == postID
                      select item).ToList();
            return us;
        }
        public List<Post> getAllPost()
        {
            using var db = new BloodDonorContext();
            var us = (from item in db.Posts
                      select item).ToList();
            return us;
        }
    }
}