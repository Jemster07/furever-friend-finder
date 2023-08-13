using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PetFinderController : ControllerBase
    {
        public PetFinderService finderDao;
        public PetFinderController(PetFinderService finderDao)
        {
            this.finderDao = finderDao;
        }

        [HttpGet("/petfinder/type/{petType}/")]
        public ActionResult<List<PetApi>> ListAnimals(string petType)
        {    
                return finderDao.GetAnimalsByType(petType);
        }

        [HttpGet("/petfinder/breed/{breed}/")]
        public ActionResult<List<PetApi>> ListBreeds(string breed)
        {
            return finderDao.GetAnimalByBreed(breed);
        }
        [HttpGet("/petfinder/location/{address}/")]
        public ActionResult<List<PetApi>> ListByLoc(string address)
        {
            return finderDao.GetAnimalByZip(address);
        }

    }
}
