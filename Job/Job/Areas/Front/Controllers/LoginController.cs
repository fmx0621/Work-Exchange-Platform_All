using Microsoft.AspNetCore.Mvc;

namespace Job.Areas.Front.Controllers
{
    [Area("Front")]
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
