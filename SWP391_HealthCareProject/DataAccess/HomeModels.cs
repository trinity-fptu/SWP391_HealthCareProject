﻿using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HomeModels
    {
        BloodDonorContext bloodDonorContext = new BloodDonorContext();
        public List<Post> PostViewModel { get; set; }

        public Post GetPostById(int id)
        {
            Post p = bloodDonorContext.Posts.Where(x => x.PostId == id).FirstOrDefault();
            return p;
        }

        public Campaign GetCampaignById(int id)
        {
            Campaign c = bloodDonorContext.Campaigns.Where(x => x.CampaignId == id).FirstOrDefault();
            return c;
        }

        public User GetUserById(int id) => bloodDonorContext.Users.Where(x => x.UserId == id).FirstOrDefault();

        public Volunteer GetVolunteerById(int id)
        {
            Volunteer c = bloodDonorContext.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();
            return c;
        }

        public List<Campaign> GetCampaign() => bloodDonorContext.Campaigns.ToList();
        public List<Post> GetPost() => bloodDonorContext.Posts.ToList();

        public List<User> UserViewModel { get; set; }

        public List<Campaign> CampaignViewModel { get; set; }
        public List<Volunteer> VolunteerViewModel { get; set; }

    }
}
