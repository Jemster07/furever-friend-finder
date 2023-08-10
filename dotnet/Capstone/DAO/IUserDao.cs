using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User AddUser(RegisterUser registerUser);

        //Delete User -> admin only
        //Update User
            //If admin, change address, role, application status
            //If friend, change address
        //List users by user id
    }
}
