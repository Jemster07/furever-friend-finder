using Capstone.Models;

namespace Capstone.DAO
{
    public interface IAdopterDao
    {
        Adopter GetAdopter(int petId);
        Adopter AssignAdopter(Pet adoptedPet, int adopterId);
    }
}
