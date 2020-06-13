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

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(new { result });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Get records of employee by its id
        [HttpGet]
        [Route("{UserId}")]
        public IActionResult GetEmployeeRecordById(int UserId)
        {
            try
            {
                if (UserId != employeeBL.GetEmployeeRecordById(UserId).UserId)
                {
                    return NotFound();
                }
                
                var result = employeeBL.GetEmployeeRecordById(UserId);

                return Ok(new { result });
            }
            catch (Exception)
            {
                return BadRequest(UserId);
            }
        }

        //Add an employee's record to the database
        [HttpPost]
        public IActionResult AddEmployeesRecords(EmployeesTableDetails employees)
        {
            try
            {
                var result = employeeBL.AddEmployeesRecords(employees);

                return Ok(new { result });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Delete an employee's record by its id from database 
        [Authorize (Roles = "Admin")]
        [HttpDelete]
        [Route("{UserId}")]
        public IActionResult DeleteEmployeeRecordById(int UserId)
        {
            try
            {
                employeeBL.DeleteEmployeeRecordById(UserId);
                return Ok("Data deleted");
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        //Update Employee record
        [Authorize (Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployeeRecord(EmployeesTableDetails employees)
        {
            try
            {
                var result = employeeBL.UpdateEmployeeRecord(employees);
                return Ok(new { result });
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
