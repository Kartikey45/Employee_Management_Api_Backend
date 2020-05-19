using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        //Configuration initialized
        private readonly IConfiguration Configuration;

        //constructor 
        public UserRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Method to add user details
        public UserRegistration AddUserDetails(UserRegistration user)
        {
            try
            {
                string connect = Configuration.GetConnectionString("MyConnection");
                using (SqlConnection Connection = new SqlConnection(connect))
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertDetails", Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                    sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Address", user.Address);
                    sqlCommand.Parameters.AddWithValue("@Designation", user.Designation);
                    sqlCommand.Parameters.AddWithValue("@Salary", user.Salary);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                    //connection open 
                    Connection.Open();

                    //Execute query
                    sqlCommand.ExecuteNonQuery();

                    //connection close
                    Connection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
