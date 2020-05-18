using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace RepositoryLayer.Interface
{
    // Interface of Repository layer
    public interface IEmployeeRL
    {
        //Method for Getting records of all the employees in the table
        List<EmployeesTableDetails> GetEmployeesRecords();

        //Method to add an Employee's data in the table
        EmployeesTableDetails AddEmployeesRecords(EmployeesTableDetails employees);

        //Method to get empoyee data by its Id
        EmployeesTableDetails GetEmployeeRecordById(int UserId);
    }
}
