using fitneesCenterMS.Data;
using fitneesCenterMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fitneesCenterMS.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalMembers = await _context.Users.CountAsync();

            var totalAppointments = await _context.Appointments.CountAsync();

            var topTrainer = await _context.Appointments
                .GroupBy(a => a.Trainer.FullName)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefaultAsync();

            var topService = await _context.Appointments
                .GroupBy(a => a.Service.Name)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefaultAsync();

            ViewBag.TotalMembers = totalMembers;
            ViewBag.TotalAppointments = totalAppointments;

            ViewBag.TopTrainerName = topTrainer != null ? topTrainer.Name : "Henüz Yok";
            ViewBag.TopTrainerCount = topTrainer != null ? topTrainer.Count : 0;

            ViewBag.TopServiceName = topService != null ? topService.Name : "Henüz Yok";
            ViewBag.TopServiceCount = topService != null ? topService.Count : 0;

            return View();
        }
    }
}