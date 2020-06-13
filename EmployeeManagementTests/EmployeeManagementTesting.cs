using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer.Model;
using EmployeeManagementAPIProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmployeeManagementTests
{
    public class EmployeeManagementTesting
    {
        EmployeeController controller;
        private readonly IEmployeeBL employeeBL;
        private readonly Mock<IEmployeeBL> _mock;

        public EmployeeManagementTesting()
        {
            _mock = new Mock<IEmployeeBL>();
            controller = new EmployeeController(_mock.Object);
        }

        // Method to Test view employee records
        [Fact]
        public void GetEmployeesRecords_when_called_returns_okrequest()
        {
            var result = controller.GetEmployeesRecords();
            try
            {
                Assert.IsType<OkObjectResult>(result);
            }
            catch (Exception)
            {
                Assert.IsType<NotFoundResult>(result);
            }
        }

        //Method to add employee record returns okResult
        [Fact]
        public void AddEmployee_ReturnsOkResult()
        {
            // Arrange
            var employee = new EmployeesTableDetails()
            {
                FirstName = "",
                LastName = "",
                Gender = "",
                Email = "",
                Address = "",
                Designation = "",
                Salary = 0,
                MobileNumber = "",
                Password = ""
            };

            // Act
            var OkResponse = controller.AddEmployeesRecords(employee);

            // Assert
            Assert.IsType<OkObjectResult>(OkResponse);
        }

        //Method to test View employee by Id returns ok result
        [Fact]
        public void ViewEmployeeRecordsById_Return_OkResult()
        {
            var OkResponse = controller.GetEmployeeRecordById(118);
            try
            {
                if (118 != employeeBL.GetEmployeeRecordById(118).UserId)
                {
                    Assert.IsType<BadRequestObjectResult>(OkResponse);
                }
                var result = employeeBL.GetEmployeeRecordById(5002);
                Assert.IsType<OkObjectResult>(OkResponse);
            }
            catch (Exception)
            {
                Assert.IsType<BadRequestObjectResult>(OkResponse);
            }
        }

        // Method to test update record by id return ok result
        [Fact]
        public void EmployeeUpdateById_Return_OkResult()
        {
            EmployeesTableDetails employee = new EmployeesTableDetails();
            var result = controller.UpdateEmployeeRecord(employee);
            Assert.IsType<OkObjectResult>(result);
        }

        //Method to test delete record by id returns ok result
        [Fact]
        public void Task_DeleteById_Return_OkResult()
        {
            var result = controller.DeleteEmployeeRecordById(123);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
