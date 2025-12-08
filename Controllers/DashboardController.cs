using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternForge.Controllers;

[Authorize]
public class DashboardController : Controller
{
    [Route("/dashboard")]
    public IActionResult Index()
    {
        // You can pass real data from DB later
        ViewBag.TotalSMEs = 87;
        ViewBag.TotalInterns = 342;
        ViewBag.ActiveRoles = 156;
        ViewBag.PendingApplications = 64;
        ViewBag.RevenueThisMonth = 18420;

        return View();
    }
}
