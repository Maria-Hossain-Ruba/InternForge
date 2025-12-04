using Microsoft.AspNetCore.Mvc;

namespace InternForge.Controllers
{
    public class SmeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
