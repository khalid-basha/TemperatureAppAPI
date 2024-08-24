using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemperatureApi.Data;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureContext _context;

        public TemperatureController(TemperatureContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostTemperatureReading([FromBody] TemperatureReading reading)
        {
            if (reading == null || reading.DeviceId <= 0)
            {
                return BadRequest("Invalid input.");
            }

            reading.Time = DateTime.UtcNow;

            _context.TempHistory.Add(reading);
            await _context.SaveChangesAsync();

            return Ok(reading);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperatureReading>>> GetTemperatureReadings()
        {
            return await _context.TempHistory.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemperatureReading(int id)
        {
            var reading = await _context.TempHistory.FindAsync(id);
            if (reading == null)
            {
                return NotFound();
            }
            return Ok(reading);
        }
    }
}
