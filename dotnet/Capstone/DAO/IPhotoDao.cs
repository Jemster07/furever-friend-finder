using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPhotoDao
    {
        Photo GetPhotoFromDB(int photoId);
        List<Photo> ListPhotosByPet(int petId);
        Photo AddPhotoToDB(NewPhoto newPhoto);
        int DeactivatePhoto(int photoId);
    }
}