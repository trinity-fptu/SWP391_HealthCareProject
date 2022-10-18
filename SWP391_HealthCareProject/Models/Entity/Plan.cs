namespace SWP391_HealthCareProject.Models.Entity
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int ExpectedTotalCost { get; set; }
        public int ExpectedAmount { get; set; }
        public int UserId { get; set; }
    }
}
