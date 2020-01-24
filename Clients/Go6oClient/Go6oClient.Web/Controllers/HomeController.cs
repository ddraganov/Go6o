using Go6oClient.Web.ABConnect;
using Go6oClient.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Go6oClient.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IABConnector connector;
        private readonly IReportConnector reportConnector;

        public HomeController(IABConnector connector, IReportConnector reportConnector)
        {
            this.connector = connector;
            this.reportConnector = reportConnector;
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
            if (control != null)
            {
                if (control.Sofia == null)
                {
                    var noSeaReport = new Report("NoSeaSide", 0, 1);
                    reportConnector.Send(noSeaReport);
                }

                if (control.Sofia != null)
                {
                    var sofiaReport = new Report("Sofia", control.Sofia == "A" ? 0 : 1, 1);
                    reportConnector.Send(sofiaReport);
                }

                if (control.NoSeaSide != null)
                {
                    var noSeaReport = new Report("NoSeaSide", control.NoSeaSide == "A" ? 0 : 1, 1);
                    reportConnector.Send(noSeaReport);
                }
            }

            return View();
        }

        public IActionResult Plovdiv(UiControl control)
        {
            if (control != null)
            {
                if (control.Plovdiv == null)
                {
                    var noSeaReport = new Report("NoSeaSide", 1, 1);
                    reportConnector.Send(noSeaReport);
                }

                if (control.Plovdiv != null)
                {
                    var plovdivReport = new Report("Plovdiv", control.Plovdiv == "A" ? 0 : 1, 1);
                    reportConnector.Send(plovdivReport);
                }

                if (control.NoSeaSide != null)
                {
                    var noSeaReport = new Report("NoSeaSide", control.NoSeaSide == "A" ? 0 : 1, 1);
                    reportConnector.Send(noSeaReport);
                }
            }

            return View();
        }

        public IActionResult Varna(UiControl control)
        {
            if (control != null)
            {
                if (control.Varna == null)
                {
                    var seaReport = new Report("SeaSide", 0, 1);
                    reportConnector.Send(seaReport);
                }

                if (control.Varna != null)
                {
                    var varnaReport = new Report("Varna", control.Varna == "A" ? 0 : 1, 1);
                    reportConnector.Send(varnaReport);
                }

                if (control.SeaSide != null)
                {
                    var seaReport = new Report("SeaSide", control.SeaSide == "A" ? 0 : 1, 1);
                    reportConnector.Send(seaReport);
                }
            }

            return View();
        }

        public IActionResult Burgas(UiControl control)
        {
            if (control != null)
            {
                if (control.Burgas == null)
                {
                    var seaReport = new Report("SeaSide", 1, 1);
                    reportConnector.Send(seaReport);
                }

                if (control.Burgas != null)
                {
                    var burgasReport = new Report("Burgas", control.Burgas == "A" ? 0 : 1, 1);
                    reportConnector.Send(burgasReport);
                }
            }

            if (control.SeaSide != null)
            {
                var seaReport = new Report("SeaSide", control.SeaSide == "A" ? 0 : 1, 1);
                reportConnector.Send(seaReport);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
