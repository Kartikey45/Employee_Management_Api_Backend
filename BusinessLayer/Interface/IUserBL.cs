using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        //Method to add user details
        UserRegistration AddUserDetails(UserRegistration user);

        //method for user login
        Response login(UserLogin user);

    }
}
