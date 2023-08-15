using Capstone.Models;

namespace Capstone.DAO
{
    public interface IEnvironDao
    {
        Environ GetEnvironment(int environmentId);
        Environ CreateEnvironment(NewEnviron newEnvironment);
        Environ UpdateEnvironment(Environ updatedEnvironment);
    }
}