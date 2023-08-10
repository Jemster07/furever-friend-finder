﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPhotoDao
    {
        Photo GetPhoto(int photoId);
        List<Photo> ListPhotosByPet(int petId);
    }
}