using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class CompanyController : Controller
    {
        public IActionResult List()
        {
            JobDbContext db = new JobDbContext();
            IEnumerable<TCompanyProfile> datas = null;
            datas = from x in db.TCompanyProfiles
                    select x;

            return View(datas);
        }

        [HttpPost]
        public IActionResult List(CKeywordViewModel vm)
        {
            JobDbContext db = new JobDbContext();
            IEnumerable<TCompanyProfile> datas = null;

            // 如果完全沒有輸入任何條件 -> 顯示全部
            if (string.IsNullOrEmpty(vm.txtKeyword) && string.IsNullOrEmpty(vm.SelectedCity))
            {
                datas = from x in db.TCompanyProfiles
                        select x;
            }
            else
            {
                datas = db.TCompanyProfiles.Where(x =>
                    (
                        (!string.IsNullOrEmpty(vm.txtKeyword) &&
                         (x.Name.Contains(vm.txtKeyword) || x.Phone.Contains(vm.txtKeyword)))
                        ||
                        (!string.IsNullOrEmpty(vm.SelectedCity) &&
                         x.Address.Substring(0, 3) == vm.SelectedCity)
                    )
                );
            }

            return View(datas);
        }

        public IActionResult Details(int id)
        {
            JobDbContext db = new JobDbContext();

            // 用 memberId 進行 INNER JOIN
            var data = (from p in db.TCompanyProfiles
                        join v in db.TCompanyVerifications
                        on p.MemberId equals v.MemberId
                        where p.MemberId == id // 用傳入的 id 與 memberId 比對
                        select new CCompanyAll
                        {
                            companyProfile = p,
                            companyVerification = v
                        }).FirstOrDefault();

            if (data == null)
            {
                return NotFound(); // 如果沒有找到資料
            }

            return View(data);
        }



    }
}
