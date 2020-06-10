using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Variable declared
        private readonly IEmployeeBL employeeBL;

        //Constructor 
        public EmployeeController(IEmployeeBL _employeeBL)
        {
            employeeBL = _employeeBL;
        }

        //Get all the records of employees from the database 
        [HttpGet]
        public IActionResult GetEmployeesRecords()
        {
            try
            {
                var result = employeeBL.GetEmployeesRecords();
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get records of employee by its id
        [HttpGet]
        [Route("GetUserDetailsById/{userId}")]
        public IActionResult GetEmployeeRecordById(int UserId)
        {
            try
            {
                var result = employeeBL.GetEmployeeRecordById(UserId);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Add an employee's record to the database
        [HttpPost]
        [Route("InsertUserDetails")]
        public IActionResult AddEmployeesRecords(EmployeesTableDetails employees)
        {
            try
            {
                var result = employeeBL.AddEmployeesRecords(employees);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete an employee's record by its id from database 
        [Authorize (Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteUserDetails/{UserId}")]
        public string DeleteEmployeeRecordById(int UserId)
        {
            try
            {
                employeeBL.DeleteEmployeeRecordById(UserId);
                return "Data deleted";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update Employee record
        [Authorize (Roles = "Admin")]
        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IActionResult UpdateEmployeeRecord(EmployeesTableDetails employees)
        {
            try
            {
                var result = employeeBL.UpdateEmployeeRecord(employees);
                return Ok(new { result });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
