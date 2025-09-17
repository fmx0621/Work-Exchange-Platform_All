using Microsoft.EntityFrameworkCore;

namespace Job.Models
{
    public interface IFMemberCommentRepository
    {
        IEnumerable<TMemberComment> GetComments(int memberId);
        void AddComment(TMemberComment comment);
    }

    public class AppDbContext : DbContext   // EF6
    {
        public DbSet<TMemberComment> FMemberComments { get; set; }
    }

    public class FMemberCommentRepository : IFMemberCommentRepository
    {
        private readonly AppDbContext _db;
        public FMemberCommentRepository(AppDbContext db) { _db = db; }

        public IEnumerable<TMemberComment> GetComments(int memberId)
            => _db.FMemberComments.Where(x => x.MemberId == memberId)
                                  .OrderByDescending(x => x.DateTime)
                                  .ToList();

        public void AddComment(TMemberComment comment)
        {
            comment.DateTime = DateOnly.FromDateTime(DateTime.Now);
            _db.FMemberComments.Add(comment);
            _db.SaveChanges();
        }
    }
}
