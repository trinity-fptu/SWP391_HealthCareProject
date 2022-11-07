using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.DataAccess
{
    public class HomeDAO
    {
        public class View3
        {
            public List<Post> post { get; set; }
            public List<Campaign> campaigns { get; set; }
            public List<Volunteer> volunteer { get; set; }
        }
    }
}
