using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class EnvironController : ControllerBase
    {
        private IEnvironDao environDao;
        public EnvironController(IEnvironDao environDao)
        {
            this.environDao = environDao;
        }

        [HttpGet("/environments/{environmentId}")]
        public ActionResult<Environ> GetEnvironment(int environmentId)
        {
            try
            {
                return Ok(environDao.GetEnvironment(environmentId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/environments/add")]
        public ActionResult<Environ> CreateEnvironment(NewEnviron newEnvironment)
        {
            try
            {
                return Ok(environDao.CreateEnvironment(newEnvironment));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/environments/{environmentId}/update")]
        public ActionResult<Environ> UpdateEnvironment(Environ updatedEnvironment)
        {
            try
            {
                return Ok(environDao.UpdateEnvironment(updatedEnvironment));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
