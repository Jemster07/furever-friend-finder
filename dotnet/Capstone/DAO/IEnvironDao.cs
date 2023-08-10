using Capstone.Models;

namespace Capstone.DAO
{
    public interface IEnvironDao
    {
        Environ GetEnvironment(int environmentId);
        Environ CreateEnvironment(Environ newEnvironment);
        Environ UpdateEnvironment(Environ updatedEnvironment);
    }
}