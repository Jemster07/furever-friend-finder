using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User AddUser(RegisterUser registerUser);

        //Change user application status


        //List users by user id for directory

        
        //List users by user id where role is friend AND app_status is pending
        //for admin application approval page


        //These are optional "nice to have" methods we can add later if we have time:

        //Admin: Delete user
        //Admin: Change user role
        //Admin OR Friend: Change address
    }
}
