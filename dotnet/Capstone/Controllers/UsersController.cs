using System;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Data.SqlClient;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class UsersController : ControllerBase
    {
        private IUserDao userDao;
        public UsersController(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        // friend/admin directory

        [HttpGet("/directory/friend")]
        public ActionResult<List<DisplayUser>> GetFriendDirectory()
        {
            try
            {
                List<DisplayUser> activeUsers = userDao.ListActiveUsers();

                if (activeUsers.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(activeUsers);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/directory/friend/{username}")]
        public ActionResult<User> GetUser(string username)
        {
            try
            {
                User fetchedUser = userDao.GetUser(username);

                if (fetchedUser.ApplicationStatus != "approved" || fetchedUser.IsInactive)
                {
                    return Unauthorized("Access denied");
                }
                else
                {
                    return Ok(fetchedUser);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // users who are adopters

        [HttpGet("/directory/friend/adopter/{petId}")]
        public ActionResult<User> GetAdopter(int petId)
        {
            try
            {
                User adopter = userDao.GetAdopter(petId);

                if (!adopter.IsAdopter || adopter.IsInactive)
                {
                    return Unauthorized("Access denied");
                }
                else
                {
                    return Ok(adopter);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // admin application approval page

        //[Authorize(Roles = "admin")]
        [HttpGet("/application/list")]
        public ActionResult<List<DisplayUser>> GetPendingUsers()
        {
            try
            {
                List<DisplayUser> pendingUsers = userDao.ListPendingUsers();

                if (pendingUsers.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(pendingUsers);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpPut("/application/update/{username}")]
        public ActionResult<User> ApproveRejectApp(User updatedUser,string username)
        {
            try
            {
                if (!(updatedUser.ApplicationStatus == "rejected" || updatedUser.ApplicationStatus == "approved"))
                {
                    return BadRequest("Incorrect status type: Select [rejected] or [approved]");
                }
                else
                {
                    return Ok(userDao.ChangeAppStatus(updatedUser));
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/directory/friend/adopter/register")]
        public ActionResult<Adopter> RegisterAdopter(Adopter adopter)
        {
            try
            {
                return Ok(userDao.RegisterAdopter(adopter));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPut("/directory/friend/adopter/update/{username}")]
        public ActionResult<User> UpdateAdopterStatus(string username)
        {
            try
            {
                return Ok(userDao.UpdateAdopterStatus(username));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}