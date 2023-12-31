﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User GetAdopter(int petId);
        User AddUser(RegisterUser registerUser);
        
        //UserController class should pass in both the admin user calling the method
        //and the user to be changed, to confirm the admin's role before execution
        User ChangeAppStatus(User updatedUser);

        Adopter RegisterAdopter(Adopter adopter);

        User UpdateAdopterStatus(string username);

        //List active users for directory
        List<DisplayUser> ListActiveUsers();

        //List users where role is friend AND app_status is pending
        //for admin application approval page
        //UserController class should pass in the admin user to confirm permission
        //to view the page is granted
        List<DisplayUser> ListPendingUsers();
        List<DisplayUser> ListAllUsers();

        //These are optional "nice to have" methods we can add later if we have time:

        //Admin: Delete user
        //Admin: Change user role
        //Admin OR Friend: Change address
    }
}
