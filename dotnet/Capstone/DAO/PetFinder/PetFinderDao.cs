using Capstone.Controllers;
using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.PetFinder
{
    public class PetFinderDao : IPetFinderDao
    {
        public List<PetApi> GetAnimalByBreed(string breed)
        {
            throw new System.NotImplementedException();
        }

        public List<PetApi> GetAnimalByZip(string zip)
        {
            throw new System.NotImplementedException();
        }

        public List<PetApi> GetAnimalsByType(string animalType)
        {
            throw new System.NotImplementedException();
        }
    }
}
