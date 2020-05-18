using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
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
        [Route("")]
        public IActionResult GetEmployeesRecords()
        {
            var result = employeeBL.GetEmployeesRecords();
            return Ok(new {result}) ;
        }

        //Get records of employee by its id
        [HttpGet]
        [Route("{UserId}")]
        public IActionResult GetEmployeeRecordById(int UserId)
        {
            var result = employeeBL.GetEmployeeRecordById(UserId);
            return Ok(new { result});
        }

        //Add an employee's record to the database
        [HttpPost]
        [Route("")]
        public IActionResult AddEmployeesRecords(EmployeesTableDetails employees)
        {
            var result = employeeBL.AddEmployeesRecords(employees);
            return Ok(new { result });
        }
    }
}
