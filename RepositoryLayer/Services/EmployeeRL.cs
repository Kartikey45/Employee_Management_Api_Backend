using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    //Child class of repository layer implementing the interface for managing data of Employees in database table
    public class EmployeeRL : IEmployeeRL
    {
        // Initialize variable for connection string of database
        string ConnectionString = @"Data Source=WINDOWS-SRLO9KL\SQLEXPRESS;Initial Catalog=EmployeeManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Method to add an Employee's data in the table
        public EmployeesTableDetails AddEmployeesRecords(EmployeesTableDetails employees)
        {
            //Stored Procedure initialized
            string Procedure = "spEmployeesAddOrEdit";

            try
            {
                using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
                {
                    //Calling the stored procedure
                    SqlCommand sqlCommand = new SqlCommand(Procedure, Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", employees.UserId);
                    sqlCommand.Parameters.AddWithValue("@FirstName", employees.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", employees.LastName);
                    sqlCommand.Parameters.AddWithValue("@Gender", employees.Gender);
                    sqlCommand.Parameters.AddWithValue("@Email", employees.Email);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", employees.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Address", employees.Address);
                    sqlCommand.Parameters.AddWithValue("@Designation", employees.Designation);
                    sqlCommand.Parameters.AddWithValue("@Salary", employees.Salary);
                    sqlCommand.Parameters.AddWithValue("@UserName", employees.UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", employees.Password);

                    //connection open 
                    Connection.Open();

                    //Execute query
                    sqlCommand.ExecuteNonQuery();

                    //connection close
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employees;
        }

        //Method for Getting records of all the employees in the table
        public List<EmployeesTableDetails> GetEmployeesRecords()
        {
            //Stored Procedure initialized
            string Procedure = "spEmployeesViewById";

            // Creat list of recoeds of all the employee
            List<EmployeesTableDetails> employees = new List<EmployeesTableDetails>();

            try
            {
                using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
                {
                    //Calling stored procedure
                    SqlCommand sqlCommand = new SqlCommand(Procedure, Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    //Connection open
                    Connection.Open();

                    //Read the data by using sql command
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        EmployeesTableDetails employeesTable = new EmployeesTableDetails();
                        employeesTable.UserId = Convert.ToInt32(dataReader["UserId"].ToString());
                        employeesTable.FirstName = dataReader["FirstName"].ToString();
                        employeesTable.LastName = dataReader["LastName"].ToString();
                        employeesTable.Gender = dataReader["Gender"].ToString();
                        employeesTable.Email = dataReader["Email"].ToString();
                        employeesTable.MobileNumber = long.Parse(dataReader["MobileNumber"].ToString());
                        employeesTable.Address = dataReader["Address"].ToString();
                        employeesTable.Designation = dataReader["UserId"].ToString();
                        employeesTable.Salary = Convert.ToDouble(dataReader["Salary"].ToString());
                        employeesTable.UserName = dataReader["UserName"].ToString();
                        employeesTable.Password = dataReader["Password"].ToString();
                    }

                    //Connection close
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employees;
        }
    }
}
