using Cw4.Models;
using Cw4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cw4.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IDbService _sqlDbService;
        public AnimalController(IDbService dbService)
        {
            _sqlDbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAnimals(string orderBy)
        {
            List<string> possibleOrderBy = new List<string> { "name", "description", "category", "area" };
            if (!possibleOrderBy.Contains(orderBy) && orderBy != null) {
                return BadRequest($"Wrong parameter {orderBy}, please use one of (name, description, category, area)");
            }
            if (orderBy == null) { orderBy = "name"; }
            var animals = _sqlDbService.GetAnimals(orderBy);
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _sqlDbService.AddAnimal(animal);

            return NoContent();
        }

        [HttpPut("{idAnimal}")]
        public IActionResult PutAnimal(Animal animal)
        {
            _sqlDbService.PutAnimal(animal);

            return Ok($"Animal updated");

        }

        [HttpDelete("{idAnimal}")]
        public IActionResult RemoveAnimal(string idAnimal)
        {
            _sqlDbService.RemoveAnimal(idAnimal);

            return Ok($"Animal deleted");
        }


    }
}
