using Microsoft.AspNetCore.Mvc;
using AnimalApi.Data;
using AnimalApi.Models;

namespace AnimalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalRepository _animalRepository;

        public AnimalsController(AnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string orderBy = "name")
        {
            var validOrderBy = new[] { "name", "description", "category", "area" };
            if (!validOrderBy.Contains(orderBy.ToLower()))
            {
                orderBy = "name";
            }

            var animals = _animalRepository.GetAnimals(orderBy);
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }

            _animalRepository.AddAnimal(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.IdAnimal }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Animal animal)
        {
            if (animal == null || id != animal.IdAnimal)
            {
                return BadRequest();
            }

            _animalRepository.UpdateAnimal(id, animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _animalRepository.DeleteAnimal(id);
            return NoContent();
        }
    }
}
