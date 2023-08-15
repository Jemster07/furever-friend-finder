using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class PhotoController : ControllerBase
    {
        string directoryPath = ".\\Pet_Photos\\";
        private IPhotoDao photoDao;

        public PhotoController(IPhotoDao photoDao)
        {
            this.photoDao = photoDao;
        }

        // Writes user uploaded image to file directory

        [HttpPost("/photo/save/{petId}")]
        public ActionResult<Photo> SaveUserImage(IFormFile formFile, int petId)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                if (formFile.Length > 0)
                {
                    string filePath = Path.Combine(directoryPath, formFile.FileName);

                    using (FileStream stream = System.IO.File.Create(filePath))
                    {
                        formFile.CopyTo(stream);
                    }

                    NewPhoto newPhoto = new NewPhoto();

                    newPhoto.PetId = petId;
                    newPhoto.PhotoUrl = filePath;
                    newPhoto.IsInactive = false;

                    return Ok(photoDao.AddPhotoToDB(newPhoto));
                }
                else
                {
                    return UnprocessableEntity("Unable to process uploaded image");
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // Grabs image from file directory and sends it up to the front end

        [HttpGet("/photo/retrieve/{photoId}")]
        public ActionResult RetrieveImage(int photoId)
        {
            Photo fetchedPhoto = photoDao.GetPhotoFromDB(photoId);

            try
            {
                if (fetchedPhoto == null)
                {
                    return Content("Missing file");
                }
                else
                {                    
                    string photoUrlLower = fetchedPhoto.PhotoUrl.ToLower();

                    Byte[] b = System.IO.File.ReadAllBytes(photoUrlLower);

                    if (photoUrlLower.Contains(".jpg") || photoUrlLower.Contains(".jpeg"))
                    {
                        return File(b, "image/jpeg");
                    }
                    else if (photoUrlLower.Contains(".png"))
                    {
                        return File(b, "image/png");
                    }
                    else if (photoUrlLower.Contains(".heic"))
                    {
                        return File(b, "image/heic");
                    }
                    else if (photoUrlLower.Contains(".tiff"))
                    {
                        return File(b, "image/tiff");
                    }
                    else if (photoUrlLower.Contains("bmp"))
                    {
                        return File(b, "image/bmp");
                    }
                    else
                    {
                        return BadRequest("File type not supported");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // Deactivate photo

        [HttpPut("/photo/delete/{photoId}")]
        public ActionResult<int> DeletePhoto(int photoId)
        {
            try
            {
                int result = photoDao.DeactivatePhoto(photoId);

                if (result != 0)
                {
                    return StatusCode(412);
                }
                else
                {
                    return Ok("Image successfully deleted");
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // List photos by pet id

        [HttpGet("/photo/{petId}/list")]
        public ActionResult<List<Photo>> GeneratePhotoList(int petId)
        {
            try
            {
                List<Photo> photoList = photoDao.ListPhotosByPet(petId);

                if (photoList.Count <= 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(photoList);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
