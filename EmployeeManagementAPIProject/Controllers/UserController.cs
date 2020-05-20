using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var result = userBL.AddUserDetails(user);
            return Ok(new { result });
        }

        [HttpPost("login")]
        public IActionResult login(UserLogin user)
        {
            var result = userBL.login(user);
            return Ok(new { result });
        }
    }
}