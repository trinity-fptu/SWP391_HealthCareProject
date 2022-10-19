using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignLocations = new HashSet<CampaignLocation>();
            Posts = new HashSet<Post>();
        }

        public int CampaignId { get; set; }
        public string Name { get; set; } = null!;
        public int NumOfVolunteer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Province { get; set; } = null!;
        public double? Cost { get; set; }
        public int PlanId { get; set; }

        public virtual Plan Plan { get; set; } = null!;
        public virtual ICollection<CampaignLocation> CampaignLocations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
