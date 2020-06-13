using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Services;

namespace EmployeeManagementAPIProject.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //variable initialized
        private readonly IUserBL userBL;

        private readonly IConfiguration _config;

        Sender sender = new Sender();

        //constructor
        public UserController(IUserBL _userBL, IConfiguration config)
        {
            userBL = _userBL;
            _config = config;
        }

        //Method of User Registration
        [HttpPost("register")]
        public IActionResult register(UserRegistration user)
        {
            try
            {
                var result = userBL.AddUserDetails(user);
                bool success = false;
                string message;
                if (result.status == "Invalid Email")
                {
                    message = "Registration Failed";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Registration Successfull";
                    string msmqRecordInQueue =  Convert.ToString(user.FirstName) + Convert.ToString(user.LastName) + "\n" + message + "\n Email : " + Convert.ToString(user.Email) + "\n Password : " + Convert.ToString(user.Password);
                    sender.Message(msmqRecordInQueue);
                    return Ok(new { success, message});
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Method of User Login 
        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin(UserLogin login)
        {
            try
            {
                UserRegistration data = userBL.login(login);
                bool success = false;
                string message, jsonToken;

                if (data == null)
                {
                    message = "Enter Valid Email & Password";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Login Successfully";

                    //Token generated
                    jsonToken = CreateToken(data, "Login");

                    return Ok(new { success, message, jsonToken });
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Token creation
        private string CreateToken(UserRegistration responseData, string type)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, responseData.Designation));
                claims.Add(new Claim("Email", responseData.Email.ToString()));
                claims.Add(new Claim("Password", responseData.Password.ToString()));

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}