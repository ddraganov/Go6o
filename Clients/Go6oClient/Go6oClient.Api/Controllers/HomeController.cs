using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Go6oClient.Api.Models;

namespace Go6oClient.Api.Controllers
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
