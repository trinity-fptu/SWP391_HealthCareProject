using Microsoft.SqlServer.Management.Smo;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HospitalRedCrossDAO
    {
        public static HospitalRedCross? GetHRByAddress(string hrAddress)
        {
            using var db = new BloodDonorContext();
            var HR = db.HospitalRedCrosses.FirstOrDefault(x => x.Address == hrAddress);
            return HR;
        }
        public static HospitalRedCross? GetHRById(int rhId)
        {
            using var db = new BloodDonorContext();
            var HR = db.HospitalRedCrosses.FirstOrDefault(x => x.Rhid == rhId);
            return HR;
        }
        public Campaign getCampaignById(int id)
        {
            using var db = new BloodDonorContext();
            var cam = db.Campaigns.Find(id);
            return cam;
        }
        public Plan GetPlansById(int id)
        {
            using var db = new BloodDonorContext();
            var plan = db.Plans.Find(id);
            return plan;
        }
        public Post GetPostById(int id)
        {
            using var db = new BloodDonorContext();
            var post = db.Posts.Find(id);
            return post;
        }
        public void UpdatePostById(Post post)
        {
            using var db = new BloodDonorContext();
            Post _post = GetPostById(post.PostId);
            try
            {
                if (_post != null)
                {
                    db.Posts.Update(post);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdatePlanById(Plan plan)
        {
            using var db = new BloodDonorContext();
            Plan _plan = GetPlansById(plan.PlanId);
            try
            {
                if (_plan != null)
                {
                    db.Plans.Update(plan);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Plan does not exít");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateCampaign(Campaign campaign)
        {
            try
            {
                using var db = new BloodDonorContext();
                Campaign _campaign = getCampaignById(campaign.CampaignId);
                if (_campaign != null)
                {
                    db.Campaigns.Update(campaign);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Campaign does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void deleteCampaign(int id)
        {
            using var db = new BloodDonorContext();
            try
            {
                Campaign campaign = getCampaignById(id);
                Post post = PostDAO.GetPostByCampaignId(campaign.CampaignId);
                CampaignLocationDAO.DeleteCampaignLocation(campaign.CampaignId);
                if(post != null)
                {
                    db.Posts.Update(post);
                    if (campaign != null)
                    {
                        db.Campaigns.Remove(campaign);
                        db.SaveChanges();
                    }

                    else
                    {
                        throw new Exception("Campaign does not exít");
                    }
                }
                else
                {
                    if (campaign != null)
                    {
                        db.Campaigns.Remove(campaign);
                        db.SaveChanges();
                    }

                    else
                    {
                        throw new Exception("Campaign does not exít");
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void deletePost(int id)
        {
            using var db = new BloodDonorContext();
            try
            {
                Post post = GetPostById(id);
                if (post != null)
                {

                    db.Posts.Remove(post);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Post does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void deletePlan(int id)
        {
            using var db = new BloodDonorContext();
            try
            {
                Plan plan = GetPlansById(id);
                Campaign campaign = CampaignDAO.GetCampaignByPlanId(plan.PlanId);
                if(campaign != null)
                {
                    if (plan != null)
                    {
                        db.Campaigns.Remove(campaign);
                        db.Plans.Remove(plan);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Plan does not exít");
                    }
                }else if(campaign == null)
                {
                    if (plan != null)
                    {
                        
                        db.Plans.Remove(plan);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Plan does not exít");
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateHR(HospitalRedCross HR)
        {
            using var db = new BloodDonorContext();
            try
            {
                if (HR != null)
                {
                    db.HospitalRedCrosses.Update(HR);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("HR does not exít");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}