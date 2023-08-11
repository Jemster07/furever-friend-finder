using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPhotoDao
    {
        Photo GetPhoto(int photoId);
        List<Photo> ListPhotosByPet(int petId);
        Photo AddPhoto(NewPhoto newPhoto);
        Photo UpdatePhoto(Photo photoToUpdate);
    }
}