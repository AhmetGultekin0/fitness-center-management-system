using fitneesCenterMS.Data;
using fitneesCenterMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fitneesCenterMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrainersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainersApi
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetTrainers()
        {
            
            var trainers = await _context.Trainers
                .Select(t => new
                {
                    t.Id,
                    t.FullName,
                    t.Specialization,
                    TotalAppointments = t.Appointments.Count() 
                })
                .ToListAsync();

            return Ok(trainers);
        }

        // GET: api/TrainersApi/Filter/Fitness
        
        [HttpGet("Filter/{specialization}")]
        public async Task<ActionResult<IEnumerable<object>>> GetTrainersBySpec(string specialization)
        {
            var trainers = await _context.Trainers
                .Where(t => t.Specialization.Contains(specialization)) 
                .Select(t => new
                {
                    t.Id,
                    t.FullName,
                    t.Specialization
                })
                .ToListAsync();

            if (!trainers.Any())
            {
                return NotFound("Bu uzmanlık alanında antrenör bulunamadı.");
            }

            return Ok(trainers);
        }
    }
}