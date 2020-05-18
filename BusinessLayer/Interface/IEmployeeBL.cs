using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    //Interface of Business layer
    public interface IEmployeeBL
    {
        //Method to get employee's record
        List<EmployeesTableDetails> GetEmployeesRecords();

        //Method to add an employee's record
        EmployeesTableDetails AddEmployeesRecords(EmployeesTableDetails employees);

        //Method to get empoyee data by its Id
        EmployeesTableDetails GetEmployeeRecordById(int UserId);
    }
}
