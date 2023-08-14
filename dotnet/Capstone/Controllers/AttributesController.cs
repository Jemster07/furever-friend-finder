using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class AttributesController : ControllerBase
    {
        private IAttributesDao attributesDao;
        public AttributesController(IAttributesDao attributesDao)
        {
            this.attributesDao = attributesDao;
        }

        [HttpGet("/attributes/{attributeId}")]
        public ActionResult<Attributes> GetAttribute(int attributeId)
        {
            try
            {
                return Ok(attributesDao.GetAttribute(attributeId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/attributes/add")]
        public ActionResult<Attributes> CreateAttribute(NewAttributes newAttributes)
        {
            try
            {
                return Ok(attributesDao.CreateAttribute(newAttributes));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/attributes/{attributesId}/update")]
        public ActionResult<Attributes> UpdateAttribute(Attributes updatedAttributes)
        {
            try
            {
                return Ok(attributesDao.UpdateAttribute(updatedAttributes));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
