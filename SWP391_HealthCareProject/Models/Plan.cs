using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class Plan
    {
        public Plan()
        {
            Campaigns = new HashSet<Campaign>();
        }

        public int PlanId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public double? ExpectedTotalCost { get; set; }
        public int? ExpectedAmount { get; set; }
        public int Rhid { get; set; }

        public virtual HospitalRedCross Rh { get; set; } = null!;
        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
