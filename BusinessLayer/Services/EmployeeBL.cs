using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    //Child class of business layer implementing the interface for managing data of Employees in database table
    public class EmployeeBL : IEmployeeBL
    {
        //Declared variable for accessing repository layer methods 
        private readonly IEmployeeRL employeeRL;

        //Constructor  
        public EmployeeBL(IEmployeeRL _employeeRL)
        {
            this.employeeRL = _employeeRL;
        }

        //Method to add employee's records 
        public EmployeesTableDetails AddEmployeesRecords(EmployeesTableDetails employee)
        {
            var result = employeeRL.AddEmployeesRecords(employee);
            return result;
        }

        //Method to get employee's records 
        public List<EmployeesTableDetails> GetEmployeesRecords()
        {
            var result = employeeRL.GetEmployeesRecords();
            return result;
        }

        //Method to get empoyee data by its Id
        public EmployeesTableDetails GetEmployeeRecordById(int UserId)
        {
            var result = employeeRL.GetEmployeeRecordById(UserId);
            return result;
        }

        //Method to delete empoyee's record by its Id
        public EmployeesTableDetails DeleteEmployeeRecordById(int UserId)
        {
            var result = employeeRL.DeleteEmployeeRecordById(UserId);
            return result;
        }

        //Method to Update record
        public EmployeesTableDetails UpdateEmployeeRecord(EmployeesTableDetails employees)
        {
            var result = employeeRL.UpdateEmployeeRecord(employees);
            return result;
        }
    }
}
