using System.Diagnostics;
using Epreuve_WAD24_ASP.NET_MVC.Models;
using Epreuve_WAD24_ASP.NET_MVC.Models.Jeux;
using Microsoft.AspNetCore.Mvc;

namespace Epreuve_WAD24_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
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

        public IActionResult Privacy()
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
