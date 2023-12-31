﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.PetFinder
{
    public interface IPetFinderDao
    {
        List<PetApi> GetAnimalsByType(string animalType);

        List<PetApi> GetAnimalByBreed(string breed);

        List<PetApi> GetAnimalByZip(string zip);
    }
}
