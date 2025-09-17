using System.Diagnostics;
using System.Text.Json;
using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class HomeController : BackBaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
