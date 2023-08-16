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

    //[Authorize]
    public class PetsController : Controller
    {
        private IPetDao petDao;
        public PetsController(IPetDao petDao)
        {
            this.petDao = petDao;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet("/directory/pet/zip/{zip}")]
        public ActionResult<List<Pet>> ListPetsByZip(string zip)
        {
            try
            {
                List<Pet> petsByZip = petDao.ListPetsByZip(zip);

                if (petsByZip.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(petsByZip);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpGet("/directory/pet/attributes/{attributes}")]
        public ActionResult<List<Pet>> ListPetsByAttributes(Attributes attributes)
        {
            try
            {
                List<Pet> petsByAttributes = petDao.ListPetsByAttributes(attributes);

                if (petsByAttributes.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(petsByAttributes);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpGet("/directory/pet/environment/{environment}")]
        public ActionResult<List<Pet>> ListPetsByEnvironments(Environ environment)
        {
            try
            {
                List<Pet> petsByEnvironments = petDao.ListPetsByEnvironments(environment);

                if (petsByEnvironments.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(petsByEnvironments);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpGet("/directory/pet/tags/{tags}")]
        public ActionResult<List<Pet>> ListPetsByTags(Tag tags)
        {
            try
            {
                List<Pet> petsByTags = petDao.ListPetsByTags(tags);

                if (petsByTags.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(petsByTags);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

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

        [HttpPut("/directory/pet/update/{updatedPet}")]
        public ActionResult<Pet> UpdatePet(Pet updatedPet)
        {
            try
            {
                return Ok(petDao.UpdatePet(updatedPet));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/directory/pet/add")]
        public ActionResult<Pet> AddPet(RegisterPet newPet)
        {
            try
            {
                return Ok(petDao.CreatePet(newPet));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
