using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPetDao
    {
        Pet GetPet(int petId);
        Pet UpdatePet(Pet updatedPet);
        Pet CreatePet(RegisterPet newPet);
        Pet UpdateAdoptionStatus(int petId);
        List<Pet> ListAvailablePets();
        List<Pet> ListPetsByZip(string zip);
        List<Pet> ListPetsByAttributes(Attributes attributes);
        List<Pet> ListPetsByEnvironments(Environ environment);
        List<Pet> ListPetsByTags(Tag tags);
        List<Pet> ListPets();
    }
}