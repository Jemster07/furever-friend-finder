using System;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

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

        // admin application approval page

        //[Authorize(Roles = "admin")]
        [HttpGet("/application/list")]
        public ActionResult<List<DisplayUser>> GetPendingUsers()
        {
            try
            {
                return Ok(userDao.ListPendingUsers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpPut("/application/update")]
        public ActionResult<User> ApproveRejectApp(string userToUpdate, string newStatus)
        {
            try
            {
                return Ok(userDao.ChangeAppStatus(userToUpdate, newStatus));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // first time login for newly approved friend
    }
}