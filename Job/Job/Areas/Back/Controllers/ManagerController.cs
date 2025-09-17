using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class ManagerController : BackBaseController
    {

        public IActionResult List(CKeywordViewModel vm)
        {

            //if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
            string keyword = vm.txtKeyword;
            bool isInt = int.TryParse(keyword, out int pid);
            JobDbContext db = new JobDbContext();
            IEnumerable<TManager> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in db.TManagers select p;
            }
            else
            {
                datas = db.TManagers.Where(m => m.ManagerName.Contains(keyword) ||
                isInt && m.PermissionId == pid || m.PermissionName.Contains(keyword));
            }
                return View(datas);
        }

        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(TManager m)
        {
            JobDbContext db = new JobDbContext();
            db.TManagers.Add(m);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            string json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            if (id == null)
                return RedirectToAction("List");
            JobDbContext DB = new JobDbContext();
            TManager manager = DB.TManagers.FirstOrDefault(M => M.ManagerId == id);
            if (manager == null)
                return RedirectToAction("List");
            DB.TManagers.Remove(manager);
            
            manager = JsonSerializer.Deserialize<TManager>(json);
            if (id == manager.ManagerId)
            {
                DB.SaveChanges();
                return RedirectToAction("Logout", "Login");
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("home");
            }
            JobDbContext db = new JobDbContext();
            TManager manager = db.TManagers.FirstOrDefault(m => m.ManagerId == id);
            if (manager == null)
                return RedirectToAction("home");
            return View(manager);
        }
        [HttpPost]
        public IActionResult Edit(TManager m)
        {
            JobDbContext db = new JobDbContext();
            TManager managerDB = db.TManagers.FirstOrDefault(M => M.ManagerId == m.ManagerId);
            if (managerDB == null)
                return RedirectToAction("List");
            managerDB.ManagerName = m.ManagerName;
            managerDB.Account = m.Account;
            managerDB.Password = m.Password;
            managerDB.PermissionId = m.PermissionId;
            managerDB.PermissionName = m.PermissionName;
            if (managerDB.ManagerName == null || managerDB.Account == null || managerDB.Password == null || managerDB.PermissionId == null
              || managerDB.PermissionName == null)
                return View(m);
            db.SaveChanges();
            return RedirectToAction("List");


        }

        public IActionResult ToggleReviewed(int id)
        {
            using var db = new JobDbContext();
            var comment = db.TMemberComments.FirstOrDefault(c => c.CommentId == id);
            if (comment != null)
            {
                comment.Reviewed = !comment.Reviewed;
                db.SaveChanges();
            }
            return RedirectToAction("CommentView");
        }


        public IActionResult CommentView(CKeywordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            JobDbContext db = new JobDbContext();

            // 先取 IQueryable，避免一開始就 ToList()
            var datas = db.TMemberComments.AsQueryable();

            // 如果有輸入關鍵字 → 篩選會員名稱
            if (!string.IsNullOrEmpty(keyword))
            {
                datas = datas.Where(m => m.MemberName.Contains(keyword));
            }

            // 如果有選擇審核條件 (True/False)
            if (!string.IsNullOrEmpty(vm?.txtReviewedKeyword))
            {
                bool reviewed = Convert.ToBoolean(vm.txtReviewedKeyword);
                datas = datas.Where(m => m.Reviewed == reviewed);
            }

            return View(datas.ToList());
        }
    }
}
