using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class Participate
    {
        public int VolunteerId { get; set; }
        public int CampaignId { get; set; }
        public string Location { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int? BloodAmount { get; set; }

        public virtual Campaign Campaign { get; set; } = null!;
        public virtual Volunteer Volunteer { get; set; } = null!;
    }
}
