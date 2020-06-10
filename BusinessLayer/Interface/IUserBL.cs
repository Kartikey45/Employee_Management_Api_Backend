using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        //Method to add user details
        Response AddUserDetails(UserRegistration user);

        //method for user login
        UserRegistration login(UserLogin user);
    }
}
