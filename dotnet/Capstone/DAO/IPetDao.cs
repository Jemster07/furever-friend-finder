using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPetDao
    {
        //Get pet by id
        Pet GetPet(int petId);

        //Get list of pets by user id
        List<Pet> GetListOfPets(int petId);

        //Get list of pets by zip code
        List<Pet> GetListByZip(Address zipAddress);

        //Get list of pets by adopter id
        List<Pet> GetPetsByAdopter(int adopterId);
        //Update pet by id
        Pet UpdatePetById(Pet updatedPet, Attributes updatedAttributes, Environ updatedEnvironment, Tag updatedTags, Address updatedAddress);
        //Add new pet
        Pet CreateNewPet(Pet newPet, Attributes newAttributes, Environ newEnvironment, Tag newTag, CreateAddress newAddress);
        //Get pet by attributes, environments, and tags
        Pet GetPetByAttribute(Attributes attributes);
        Pet GetPetByEnvironment(Environ environment);
        Pet GetPetByTags(Tag tags);
    }
}