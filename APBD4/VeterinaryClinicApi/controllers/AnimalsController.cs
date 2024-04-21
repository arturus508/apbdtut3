using Microsoft.AspNetCore.Mvc;
using VeterinaryClinicApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace VeterinaryClinicApi.Controllers
{
    // API controller for managing animal records
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalManager : ControllerBase
    {
        private static List<Animal> _animalList = new List<Animal>();
        private static int _nextAnimalId = 1;     // Tracking ID for new animals entris

            // fetch evbery  animal
        [HttpGet]
        public ActionResult<List<Animal>> FetchAll()
        {
            return _animalList;
        }

            // Get 1  singl animal by their  ID
        [HttpGet("{id}")]
        public ActionResult<Animal> FetchById(int id)
        {
            var pet = _animalList.FirstOrDefault(a => a.Id == id);
            if (pet == null) return NotFound("No animal found with this ID.");
            return pet;
        }

         // Add new animal to  registry
        [HttpPost]
        public ActionResult<Animal> RegisterNewAnimal(Animal animal)
        {
            animal.Id = _nextAnimalId++;
            _animalList.Add(animal);
            return CreatedAtAction(nameof(FetchById), new { id = animal.Id }, animal);
        }

            // updatee    existing animal; info
        [HttpPut("{id}")]
        public ActionResult ModifyAnimal(int id, Animal animal)
        {
            var animalIndex = _animalList.FindIndex(a => a.Id == id);
            if (animalIndex == -1) return NotFound("No matching animal found.");

            _animalList[animalIndex] = animal;
            return NoContent();
        }

                // Remove a animal from  registry
        [HttpDelete("{id}")]
        public ActionResult RemoveAnimal(int id)
        {
            var animalIndex = _animalList.FindIndex(a => a.Id == id);
            if (animalIndex == -1) return NotFound("No matching animal found.");

            _animalList.RemoveAt(animalIndex);
            return NoContent();
        }
    }
}
