using Go6oClient.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Go6oClient.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var control = new UiControl()
            {
                Burgas = "A",
                NoSeaSide = "B",
                Plovdiv = "B",
                SeaSide = "A",
                Sofia = "B",
                Varna = "A"
            };

            return View(control);
        }

        public IActionResult Sofia()
        {
            return View();
        }

        public IActionResult Plovdiv()
        {
            return View();
        }

        public IActionResult Varna()
        {
            return View();
        }

        public IActionResult Burgas()
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
