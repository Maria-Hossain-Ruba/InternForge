using System;
using System.Linq;
using System.Threading.Tasks;
using InternForge.Data;
using InternForge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternForge.Controllers
{
    [Authorize(Roles = "SME,Admin")]
    public class SmeController : Controller
    {
        private readonly InternForgeContext _context;

        public SmeController(InternForgeContext context)
        {
            _context = context;
        }

        // ✅ Optional: make /Sme/Dashboard work (fixes your 404)
        [HttpGet]
        public IActionResult Dashboard()
        {
            return RedirectToAction(nameof(MyProjects));
        }

        // 1) SME: My Projects
        [HttpGet]
        public async Task<IActionResult> MyProjects()
        {
            var projects = await _context.Projects
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return View(projects);
        }

        // 2) SME: View Applications for a project
        [HttpGet]
        public async Task<IActionResult> ProjectApplications(int id) // id = ProjectID
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectID == id);

            if (project == null) return NotFound();

            var apps = await _context.Applications
                .Where(a => a.ProjectID == id)
                .OrderByDescending(a => a.AppliedAt)
                .ToListAsync();

            ViewBag.Project = project;
            return View(apps);
        }

        // 3) SME: Accept
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptApplication(int applicationId)
        {
            var app = await _context.Applications
                .FirstOrDefaultAsync(a => a.ApplicationID == applicationId);

            if (app == null) return NotFound();

            app.Status = "Accepted";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ProjectApplications), new { id = app.ProjectID });
        }

        // 3) SME: Reject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectApplication(int applicationId)
        {
            var app = await _context.Applications
                .FirstOrDefaultAsync(a => a.ApplicationID == applicationId);

            if (app == null) return NotFound();

            app.Status = "Rejected";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ProjectApplications), new { id = app.ProjectID });
        }

        // 4) OPTIONAL: Issue Certificate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IssueCertificate(int applicationId)
        {
            var app = await _context.Applications
                .FirstOrDefaultAsync(a => a.ApplicationID == applicationId);

            if (app == null) return NotFound();

            if (!string.Equals(app.Status, "Accepted", StringComparison.OrdinalIgnoreCase))
            {
                TempData["Error"] = "Only accepted applications can receive certificates.";
                return RedirectToAction(nameof(ProjectApplications), new { id = app.ProjectID });
            }

            // Prevent duplicates
            var already = await _context.Certificates.AnyAsync(c =>
                c.ProjectId == app.ProjectID && c.StudentEmail == app.ApplicantEmail);

            if (already)
            {
                TempData["Error"] = "Certificate already issued for this student in this project.";
                return RedirectToAction(nameof(ProjectApplications), new { id = app.ProjectID });
            }

            var cert = new Certificate
            {
                ProjectId = app.ProjectID,
                StudentName = app.ApplicantName,
                StudentEmail = app.ApplicantEmail,
                CertificateNumber = $"CERT-{app.ProjectID}-{DateTime.UtcNow:yyyyMMddHHmmss}",

                // ✅ DO NOT set null if your model uses non-nullable string
                FilePath = "",

                IssuedAt = DateTime.UtcNow
            };

            _context.Certificates.Add(cert);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Certificate issued successfully.";
            return RedirectToAction(nameof(ProjectApplications), new { id = app.ProjectID });
        }
    }
}
