using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //[Authorize]
    public class FileUploadController : ControllerBase
    {
        string directoryPath = ".\\dotnet\\Pet_Photos\\";
        private IPhotoDao photoDao;

        public FileUploadController(IPhotoDao photoDao, string directoryPath)
        {
            this.photoDao = photoDao;
            this.directoryPath = directoryPath;
        }

        // Writes user uploaded image to file directory

        [HttpPost("/photo/upload/{petId}")]
        public ActionResult<Photo> UploadFile(IFormFile formFile, int petId)
        {
            try
            {
                if (formFile.Length > 0)
                {
                    string directory = directoryPath;

                    string filePath = Path.Combine(directory, formFile.FileName);

                    using (FileStream stream = System.IO.File.Create(filePath))
                    {
                        formFile.CopyTo(stream);
                    }

                    NewPhoto newPhoto = new NewPhoto();

                    newPhoto.PetId = petId;
                    newPhoto.PhotoUrl = filePath;
                  
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
    }
}
