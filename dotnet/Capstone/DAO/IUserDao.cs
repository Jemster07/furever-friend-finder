using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role, string email, Address address);

        //Delete User -> admin only
        //Update User
            //If admin, change address, role, application status
            //If friend, change address
        //List users by user id
    }
}
