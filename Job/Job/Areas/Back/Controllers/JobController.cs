using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class JobController : Controller
    {
        public IActionResult List()
        {
            JobDbContext db = new JobDbContext();

            // 儲存清單
            List<CJobItem> jobList = new List<CJobItem>();

            var datas = from p in db.TJobPostings
                        join c in db.TCompanyProfiles on p.UserId equals c.MemberId
                        join s in db.TJobPostingStatuses on p.StatusId equals s.StatusId
                        select new { p, c, s };

            // 將datas資料依序存入jobList中
            foreach (var item in datas)
            {
                CJobItem x = new CJobItem();
                x.jobPosting = item.p;
                x.Company = item.c;
                x.jobPostingStatus = item.s;

                jobList.Add(x);
            }

            return View(jobList);
        }

        public ActionResult Details(int? id) {
            if (id == null)
                return RedirectToAction("List");

            using (var db = new JobDbContext()) { 
                var data = (from p in db.TJobPostings
                            join c in db.TCompanyProfiles on p.UserId equals c.MemberId
                            join s in db.TJobPostingStatuses on p.StatusId equals s.StatusId
                            join d in db.TJobPostingDetails on p.PostingId equals d.PostingId
                            where p.PostingId == id
                            select new CJobItem
                            {
                                Company = c,
                                jobPosting = p,
                                jobPostingStatus = s,
                                jobPostingDetail = d
                            }).FirstOrDefault();

                if (id == null)
                    return RedirectToAction("List");

                return View(data);
            }
        }
    }
}
