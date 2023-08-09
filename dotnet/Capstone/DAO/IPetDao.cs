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
        List<Pet> GetListbyZip(Address zipaddress);

        //Get list of pets by adopter id
        List<Pet> GetPetsByAdopter(int adopterId);
        //Update pet by id
        Pet UpdatePetById(Pet updatedPet);
        //Add new pet
        Pet CreateNewPet(Pet newPet, Attribute Atributes, Environ environment, Tag tags, Address address);
        //Get pet by attributes, environments, and tags
        Pet GetPetByAttribute(Attribute attributes);
        Pet GetPetByEnvironment(Environ environment);
        Pet GetPetByTags(Tag tags);
    }
}