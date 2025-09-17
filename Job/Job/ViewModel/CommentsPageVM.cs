namespace Job.ViewModel
{
    public class CommentsPageVM
    {
        public Job.Models.TMemberComment Input { get; set; } = new Job.Models.TMemberComment();
        public IEnumerable<Job.Models.TMemberComment> List { get; set; } = Enumerable.Empty<Job.Models.TMemberComment>();
    }
}
