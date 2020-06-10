using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        //Method to add user details
        Response AddUserDetails(UserRegistration user);

        //Method for user login
        UserRegistration login(UserLogin user);
    }
}
