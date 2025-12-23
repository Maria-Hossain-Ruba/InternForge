using System;
using System.Linq;
using System.Threading.Tasks;
using InternForge.Data;
using InternForge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternForge.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly InternForgeContext _context;

        public ProjectsController(InternForgeContext context)
        {
            _context = context;
        }

        // GET: /Projects/Index
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return View(projects);
        }

        // GET: /Projects/Apply?id=1
        [HttpGet]
        public async Task<IActionResult> Apply(int id)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectID == id);

            if (project == null) return NotFound();

            ViewBag.Project = project;

            var model = new Application
            {
                ProjectID = id
            };

            return View(model);
        }

        // POST: /Projects/Apply
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(Application model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Project = await _context.Projects
                    .FirstOrDefaultAsync(p => p.ProjectID == model.ProjectID);

                return View(model);
            }

            model.Status = "Pending";
            model.AppliedAt = DateTime.Now;

            _context.Applications.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
