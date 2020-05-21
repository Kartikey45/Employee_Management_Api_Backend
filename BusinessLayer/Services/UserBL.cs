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
        public Response AddUserDetails(UserRegistration user)
        {
            try
            {
                var result = userDetail.AddUserDetails(user);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Response login(UserLogin user)
        {
            try
            {
                var result = userDetail.login(user);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
