using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPetDao
    {
        //Get pet by id
        Pet GetPet(int petId);

        //Get list of pets by user id
        List<Pet> ListPets(int petId);

        //Get list of pets by zip code
        List<Pet> ListPetsByZip(Address zipAddress);

        //Get list of pets by adopter id
        List<Pet> ListPetsByAdopter(int adopterId);
        //Update pet by id
        Pet UpdatePet(Pet updatedPet, Attributes updatedAttributes, Environ updatedEnvironment, Tag updatedTags, Address updatedAddress);
        //Add new pet
        Pet CreatePet(Pet newPet, Attributes newAttributes, Environ newEnvironment, Tag newTag, CreateAddress newAddress);
        //Get pet by attributes, environments, and tags
        Pet GetPetByAttributes(Attributes attributes);
        Pet GetPetByEnvironments(Environ environment);
        Pet GetPetByTags(Tag tags);
    }
}