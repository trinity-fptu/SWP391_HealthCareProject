using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class CampaignLocation
    {
        public int CampaignLocationId { get; set; }
        public int CampaignId { get; set; }
        public string Location { get; set; } = null!;

        public virtual Campaign Campaign { get; set; } = null!;
    }
}
