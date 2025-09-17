using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace Job.Areas.Front.Controllers
{
    [Area("Front")]

    public class HomeController : BackBaseController2
    {
        private readonly IFMemberCommentRepository _repo =
        new FMemberCommentRepository(new AppDbContext());
        public IActionResult CommentList(CKeywordViewModel vm)
        {
            //string keyword = vm.txtKeyword;
            //bool isInt = int.TryParse(keyword, out int pid);
            //JobDbContext db = new JobDbContext();
            //IEnumerable<MemberComment> datas = null;
            //if (string.IsNullOrEmpty(keyword))
            //{
            //    datas = from p in db.MemberComments select p;
            //}
            return View();
        }
        public IActionResult Response(int? id)
        {
       
            TMemberComment m = new TMemberComment();
            var datas = (new JobDbContext()).TMemberComments.Where(m => m.MemberId == id);
            
            return View(datas);
        }

        [HttpPost]
        public IActionResult Response(TMemberComment m)
        {
            var json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            JobDbContext db = new JobDbContext();
            var user = JsonSerializer.Deserialize<TManager>(json);
            m.UserName = user.ManagerName;
            m.UserId = user.ManagerId;
            m.DateTime = DateOnly.FromDateTime(DateTime.Now);
            m.Reviewed = false;
            db.TMemberComments.Add(m);
            CFilter f = new CFilter();
            m.Comment = f.filtered(m.Comment);
           
            db.SaveChanges();
           
            return RedirectToAction("Response", new { id = m.MemberId });
        }

        [HttpPost]
        public ActionResult Comments(TMemberComment input)
        {
            if (!ModelState.IsValid)
            {
                var list = _repo.GetComments((int)(input.MemberId));
                return View(list); // View 型別仍是 IEnumerable<FMemberComment>
            }
            _repo.AddComment(input);
            return RedirectToAction(nameof(Comments), new { memberId = input.MemberId });
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
