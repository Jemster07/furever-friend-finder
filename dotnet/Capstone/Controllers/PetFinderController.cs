using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {   

                List<PetApi> availablePets = finderDao.GetAnimalsByType(petType);
           
                if (availablePets.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(availablePets);           
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/petfinder/breed/{breed}/")]
        public ActionResult<List<PetApi>> ListBreeds(string breed)
        {
            try
            {
                List<PetApi> availablePets = finderDao.GetAnimalByBreed(breed);
                if (availablePets.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(availablePets);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
      
        [HttpGet("/petfinder/location/{address}/")]
        public ActionResult<List<PetApi>> ListByLoc(string address)
        {
            try
            {
                List<PetApi> availablePets = finderDao.GetAnimalByZip(address);
                if (availablePets.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(availablePets);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}
