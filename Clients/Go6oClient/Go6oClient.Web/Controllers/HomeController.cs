using Go6oClient.Web.ABConnect;
using Go6oClient.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Go6oClient.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IABConnector connector;

        public HomeController(IABConnector connector)
        {
            this.connector = connector;
        }

        public IActionResult Index()
        {
            var control = new UiControl()
            {
                Burgas = connector.GetValue("Burgas"),
                NoSeaSide = connector.GetValue("NoSeaSide"),
                Plovdiv = connector.GetValue("Plovdiv"),
                SeaSide = connector.GetValue("SeaSide"),
                Sofia = connector.GetValue("Sofia"),
                Varna = connector.GetValue("Varna")
            };

            return View(control);
        }

        public IActionResult Sofia(UiControl control)
        {
            return View();
        }

        public IActionResult Plovdiv(UiControl control)
        {
            return View();
        }

        public IActionResult Varna(UiControl control)
        {
            return View();
        }

        public IActionResult Burgas(UiControl control)
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
