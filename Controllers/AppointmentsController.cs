using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private static readonly List<Appointment> _appointments = new();
        private static int _nextId = 1;

        public record Appointment(int Id, int PetId, string Date, string Reason);
        public record CreateAppointmentRequest(int PetId, string Date, string Reason);

        // GET: /api/appointments
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_appointments);
        }

        // POST: /api/appointments
        [HttpPost]
        public IActionResult Create([FromBody] CreateAppointmentRequest request)
        {
            if (request == null ||
                request.PetId <= 0 ||
                string.IsNullOrWhiteSpace(request.Date) ||
                string.IsNullOrWhiteSpace(request.Reason))
            {
                return BadRequest(new { error = "PetId, Date, Reason are required" });
            }

            // ✅ التحقق أن الحيوان موجود
            var petExists = PetsController.Pets.Any(p => p.Id == request.PetId);
            if (!petExists)
            {
                return NotFound(new { error = $"PetId {request.PetId} not found" });
            }

            var appt = new Appointment(
                Id: _nextId++,
                PetId: request.PetId,
                Date: request.Date.Trim(),
                Reason: request.Reason.Trim()
            );

            _appointments.Add(appt);
            return Created($"/api/appointments/{appt.Id}", appt);
        }

        // DELETE: /api/appointments/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var index = _appointments.FindIndex(a => a.Id == id);
            if (index == -1)
                return NotFound(new { error = "Appointment not found" });

            _appointments.RemoveAt(index);
            return NoContent();
        }
    }
}
