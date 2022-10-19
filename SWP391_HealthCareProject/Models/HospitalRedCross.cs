using System;
using System.Collections.Generic;

namespace SWP391_HealthCareProject.Models
{
    public partial class HospitalRedCross
    {
        public HospitalRedCross()
        {
            HospitalRedCrossAdmins = new HashSet<HospitalRedCrossAdmin>();
            Plans = new HashSet<Plan>();
        }

        public int Rhid { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<HospitalRedCrossAdmin> HospitalRedCrossAdmins { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
