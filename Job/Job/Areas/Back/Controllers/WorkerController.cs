using Job.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class WorkerController : Controller
    {

        public IActionResult List()
        {
            JobDbContext db = new JobDbContext();
            IEnumerable<TWorkerProfile> datas = null;
            datas = from x in db.TWorkerProfiles
                    select x;


            return View(datas);
        }
        
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Create()
        {
            return View();
        }
    }
}
