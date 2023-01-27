using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DAL.Models;

namespace DAL
{
    public class DALClass
    {
        string connString = Convert.ToString(ConfigurationManager.ConnectionStrings["UserDB"]);
        public DataSet GetUsers_DAL()
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    string cmdString = "select * from Users";
                    SqlCommand cmd = new SqlCommand(cmdString, connection);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Users - " + ex.Message);
            }
        }

        public int AddUser_DAL(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into Users (Name, Email, Password) values(@item,  )", connection);

                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parameters[1] = new SqlParameter("@email", SqlDbType.NVarChar);
                    parameters[2] = new SqlParameter("@password", SqlDbType.NVarChar);

                    parameters[0].Value = user.Name;
                    parameters[1].Value = user.Email;
                    parameters[2].Value = user.Password;

                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    var result = command.ExecuteNonQuery();
                    command.CommandTimeout = 6000;
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Employees - " + ex.Message.ToString());
            }
        }

        //public string CreateUsersTable_DAL()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connString))
        //        {
        //            string cmdString = @"create database UserDB";
        //            SqlCommand cmd = new SqlCommand(cmdString, connection);
        //            try
        //            {
        //                connection.Open();
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch (SqlException ex)
        //            {
        //                return ("Error Generated. Details: " + ex.ToString());
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //        return "Database Created Successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occured while creating Table Users - " + ex.Message);
        //    }
        //}
    }
}
