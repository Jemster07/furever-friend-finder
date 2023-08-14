using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPetDao
    {
        Pet GetPet(int petId);
        Pet UpdatePet(Pet updatedPet, Attributes updatedAttributes, Environ updatedEnvironment, Tag updatedTags,
            Address updatedAddress);
        Pet CreatePet(RegisterPet newPet, Attributes newAttributes, Environ newEnvironment, Tag newTag,
            CreateAddress newAddress);
        Pet AssignAdopter(int petId, int adopterId);
        List<Pet> ListAvailablePets();
        List<Pet> ListPetsByZip(string zip);
        List<Pet> ListPetsByAttributes(Attributes attributes);
        List<Pet> ListPetsByEnvironments(Environ environment);
        List<Pet> ListPetsByTags(Tag tags);
        List<Pet> ListPets();
    }
}