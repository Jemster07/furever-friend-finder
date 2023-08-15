using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class TagController : ControllerBase
    {
        private ITagDao tagDao;
        public TagController(ITagDao tagDao)
        {
            this.tagDao = tagDao;
        }

        [HttpGet("/tags/{tagId}")]
        public ActionResult<Tag> GetTag(int tagId)
        {
            try
            {
                return Ok(tagDao.GetTag(tagId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/tags/add")]
        public ActionResult<Tag> CreateTag(NewTag newTag)
        {
            try
            {
                return Ok(tagDao.CreateTag(newTag));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/tags/{tagId}/update")]
        public ActionResult<Tag> UpdateTag(Tag updatedTags)
        {
            try
            {
                return Ok(tagDao.UpdateTag(updatedTags));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
