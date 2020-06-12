using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;

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
        public Response AddUserDetails(UserRegistration user)
        {
            Response response = new Response();

            try
            {
                //Connection string declared
                string connect = Configuration.GetConnectionString("MyConnection");

                //password encrypted
                string Password = EncryptedPassword.EncodePasswordToBase64(user.Password);

                using (SqlConnection Connection = new SqlConnection(connect))
                {
                    SqlCommand sqlCommand = new SqlCommand("UserRegistration", Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                    sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Address", user.Address);
                    sqlCommand.Parameters.AddWithValue("@Designation", user.Designation);
                    sqlCommand.Parameters.AddWithValue("@Salary", user.Salary);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Password", Password);

                    //connection open 
                    Connection.Open();

                    //declare variable
                    int status = 0;

                    //Execute query
                    status = sqlCommand.ExecuteNonQuery();

                    try
                    {
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();

                        while (dataReader.Read())
                        {
                            response.UserId = Convert.ToInt32(dataReader["UserId"].ToString());
                            response.FirstName = dataReader["FirstName"].ToString();
                            response.LastName = dataReader["LastName"].ToString();
                            response.Gender = dataReader["Gender"].ToString();
                            response.Email = dataReader["Email"].ToString();
                            response.Address = dataReader["Address"].ToString();
                            response.Designation = dataReader["Designation"].ToString();
                            response.Salary = Convert.ToDouble(dataReader["Salary"].ToString());
                            response.MobileNumber = dataReader["MobileNumber"].ToString();
                            response.Password = dataReader["Password"].ToString();
                        }
                    }
                    catch
                    {
                        Response myReturnData = new Response() { message = "Error" };
                        string json = JsonConvert.SerializeObject(myReturnData);
                    }

                    //connection close
                    Connection.Close();

                    //validation
                    if (status == 1)
                    {
                        response.status = "Valid Email";
                        response.data = "Entered";
                    }
                    else
                    {
                        response.status = "Invalid Email";
                        response.data = "Not entered";
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Method for User login
        public UserRegistration login(UserLogin user)
        {
            UserRegistration userLogin = new UserRegistration();
            try
            {
                //Connection string declared
                string connect = Configuration.GetConnectionString("MyConnection");

                //Password encrypted
                string Password = EncryptedPassword.EncodePasswordToBase64(user.Password);

                using (SqlConnection Connection = new SqlConnection(connect))
                {
                    SqlCommand sqlCommand = new SqlCommand("UserLogin", Connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", Password);

                    //connection open 
                    Connection.Open();

                    //read data form the database
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //While Loop For Reading status result from SqlDataReader.
                    while (reader.Read())
                    {
                        userLogin.UserId = Convert.ToInt32(reader["UserId"].ToString());
                        userLogin.FirstName = reader["FirstName"].ToString();
                        userLogin.LastName = reader["LastName"].ToString();
                        userLogin.Gender = reader["Gender"].ToString();
                        userLogin.Email = reader["Email"].ToString();
                        userLogin.Address = reader["Address"].ToString();
                        userLogin.Designation = reader["Designation"].ToString();
                        userLogin.Salary = Convert.ToDouble(reader["Salary"].ToString());
                        userLogin.MobileNumber = reader["MobileNumber"].ToString();
                        userLogin.Password = reader["Password"].ToString();
                    }

                    //connection close
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userLogin;
        }
    }
}
