using Microsoft.AspNetCore.Mvc;

namespace Job.ViewModel
{
    public class JobListViewModel : Controller
    {
        public int PostingId { get; set; }
        public string PostTitle { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string Status { get; set; }
        public DateTime PublishStartDate { get; set; }
        public DateTime PublishEndDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
