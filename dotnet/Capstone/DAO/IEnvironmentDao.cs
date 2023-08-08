using Capstone.Models;

namespace Capstone.DAO
{
    public interface IEnvironmentDao
    {
        Environment GetEnvironment(int petId);
        Environment CreateEnvironment(int petId, Environment newEnvironment);
        Environment UpdateEnvironment(int petId, Environment updatedEnvironment);
    }
}