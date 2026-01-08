using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        public static readonly List<Pet> Pets = new();
        public static int NextId = 1;

        public record Pet(int Id, string Name, string Type, string OwnerName);
        public record CreatePetRequest(string Name, string Type, string OwnerName);

        // GET: /api/pets
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Pets);
        }

        // POST: /api/pets
        [HttpPost]
        public IActionResult Create([FromBody] CreatePetRequest request)
        {
            if (request == null ||
                string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Type) ||
                string.IsNullOrWhiteSpace(request.OwnerName))
            {
                return BadRequest(new { error = "Name, Type, OwnerName are required" });
            }

            var pet = new Pet(
                Id: NextId++,
                Name: request.Name.Trim(),
                Type: request.Type.Trim(),
                OwnerName: request.OwnerName.Trim()
            );

            Pets.Add(pet);
            return Created($"/api/pets/{pet.Id}", pet);
        }

        // DELETE: /api/pets/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var index = Pets.FindIndex(p => p.Id == id);
            if (index == -1)
                return NotFound(new { error = "Pet not found" });

            Pets.RemoveAt(index);
            return NoContent();
        }
    }
}
