using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;

namespace EmployeeManagementAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //variable initialized
        private readonly IUserBL userBL;

        //constructor
        public UserController(IUserBL _userBL)
        {
            userBL = _userBL;
        }

        [HttpPost]
        [Route("")]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                var result = userBL.AddUserDetails(user);

                return Ok(new {result}) ;  
               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult login(UserLogin user)
        {
            try
            {
                var result = userBL.login(user);
                if (result.Email == null)
                {
                    return Ok(new
                    { 
                        status = "failed",
                        message = "login failed"
                    }
                    );
                }
                else
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "login succesfull",
                        data = result
                    }
                    );
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}