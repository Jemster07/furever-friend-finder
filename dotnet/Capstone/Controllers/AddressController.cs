using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class AddressController : ControllerBase
    {
        private IAddressDao addressDao;
        public AddressController(IAddressDao addressDao)
        {
            this.addressDao = addressDao;
        }

        [HttpGet("/address/{addressId}")]
        public ActionResult<Address> GetAddress(int addressId)
        {
            try
            {
                return Ok(addressDao.GetAddress(addressId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("/address/add")]
        public ActionResult<Address> CreateAddress(CreateAddress newAddress)
        {
            try
            {
                return Ok(addressDao.CreateAddress(newAddress));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/address/update/{addressId}")]
        public ActionResult<Address> UpdateAddress(Address updatedAddress)
        {
            try
            {
                return Ok(addressDao.UpdateAddress(updatedAddress));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
