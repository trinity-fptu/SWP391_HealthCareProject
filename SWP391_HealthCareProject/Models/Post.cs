using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Img { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? CampaignId { get; set; }
        public int Rhaid { get; set; }

        public virtual Campaign? Campaign { get; set; }
        public virtual HospitalRedCrossAdmin Rha { get; set; } = null!;
    }
}
