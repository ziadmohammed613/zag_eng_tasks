namespace JobAPI
{
    public class JobListing
    {
        public int Id { get; set; }
        public string Title { get; set; } // Ex: "Backend Developer"
        public string Company { get; set; } // Ex: "Tech Corp"
        public string Location { get; set; } // Ex: "Cairo"
        public decimal Salary { get; set; } // Ex: 15000
        public bool IsActive { get; set; } // soft delete flag
        public DateTime PostedAt { get; set; } // auto-set on creation
    }
}