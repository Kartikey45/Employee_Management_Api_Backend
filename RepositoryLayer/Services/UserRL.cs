using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

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

        //Method for User login
        public Response login(UserLogin user)
        {
            try
            {
                string connect = Configuration.GetConnectionString("MyConnection");

                using (SqlConnection Connection = new SqlConnection(connect))
                {
                    SqlCommand sqlCommand = new SqlCommand("UserLogin", Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);

                    //connection open 
                    Connection.Open();

                    //read data form the database
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    int status = 0;

                    //While Loop For Reading status result from SqlDataReader.
                    while (reader.Read())
                    {
                        status = reader.GetInt32(0);
                    }

                    //connection close
                    Connection.Close();

                    if (status == 1)
                    {
                        Response response = new Response();
                        response.status = "valid";
                        response.message = "Login Successfull";
                        response.data = user.Email;
                        return response;
                    }
                    else
                    {
                        Response response = new Response();
                        response.status = "Invalid";
                        response.message = "Login Failed";
                        response.data = user.Email;
                        return response;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        
    }
}
