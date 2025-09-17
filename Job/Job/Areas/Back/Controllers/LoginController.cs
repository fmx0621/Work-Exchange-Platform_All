using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class LoginController : Controller
    {
        /*
            待優化功能
            1.目前密碼為明碼->雜湊
            2.super驗證，防止未登入直接輸入網址進入(未登入跳轉Login)
              EX：https://localhost:7244/Back/Manager/List
         */

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            
            JobDbContext db = new JobDbContext();
            TManager m = db.TManagers.FirstOrDefault(m => m.Account == vm.txtAccount && m.Password == vm.txtPassword);
            if (m == null)
            {
                ModelState.AddModelError("", "請輸入正確帳密");



                return View(vm);
            }
                
            if (!m.Password.Equals(vm.txtPassword))
            {
                ModelState.AddModelError("", "密碼錯誤");
                return View(vm);
            }

            string json = JsonSerializer.Serialize(m);
            HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json); 
            


            return RedirectToAction("index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CDictionary.SK_LOGINED_USER);
            return RedirectToAction("Login");
        }


    }
}
