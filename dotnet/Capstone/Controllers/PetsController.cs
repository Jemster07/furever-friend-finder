using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize] //Make sure to allow the generic list pets to be displayed without login
    public class PetsController : Controller
    {
        private IUserDao userDao;
        private IPetDao petDao;
        public PetsController(IUserDao userDao, IPetDao petDao)
        {
            this.userDao = userDao;
            this.petDao = petDao;
        }

        [HttpGet("/directory/pet")]
        public ActionResult<List<Pet>> GetPetDirectory()
        {
            try
            {
                List<Pet> availablePets = petDao.ListAvailablePets();

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

        // get pet by id
        [HttpGet("/directory/pet/{petId}")]
        public ActionResult<Pet> GetPet(int petId)
        {
            try
            {
                Pet fetchedPet = petDao.GetPet(petId);

                if (fetchedPet.IsAdopted)
                {
                    return Unauthorized("Pet no longer available");
                }
                else
                {
                    return Ok(fetchedPet);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }



        // add pet

        // Get user by adopter id

        // Assign UserId to pet AdopterId
        // Updates user's IsAdopter property
        // Update pet's IsAdopted property
    }
}
