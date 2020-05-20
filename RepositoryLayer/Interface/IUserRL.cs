using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        //Method to add user details
        UserRegistration AddUserDetails(UserRegistration user);

        //Method for user login
        Response login(UserLogin user);
    }
}
