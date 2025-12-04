using Microsoft.AspNetCore.Mvc;

namespace InternForge.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
