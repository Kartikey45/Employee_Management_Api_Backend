using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        //Initialise variable 
        private readonly IUserRL userDetail;

        //constructore declare
        public UserBL(IUserRL UserDetail)
        {
            userDetail = UserDetail;
        }

        //Method to add user details
        public UserRegistration AddUserDetails(UserRegistration user)
        {
            var result = userDetail.AddUserDetails(user);
            return result;
        }

        public Response login(UserLogin user)
        {
            var result = userDetail.login(user);
            return result;
        }
    }
}
