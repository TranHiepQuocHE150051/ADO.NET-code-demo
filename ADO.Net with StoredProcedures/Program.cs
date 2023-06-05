using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ADO.Net_with_StoredProcedures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "server=(local); database=StudentDB; uid=sa; pwd=quoc1910;Encrypt=False";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Stored Procedure with no parameter
                    //SqlCommand cmd = new SqlCommand("spGetStudents", connection)
                    //{
                    //    //Specify the command type as Stored Procedure
                    //    CommandType = CommandType.StoredProcedure
                    //};
                    ////Open the Connection
                    //connection.Open();
                    //SqlDataReader sdr = cmd.ExecuteReader();
                    ////Read the data from the SqlDataReader 
                    //while (sdr.Read())
                    //{
                    //    Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);

                    //}
                    // Stored Procedure with params
                    //SqlCommand cmd = new SqlCommand()
                    //{
                    //    CommandText = "spGetStudentById",
                    //    Connection = connection,
                    //    CommandType = CommandType.StoredProcedure
                    //};
                    //SqlParameter param1 = new SqlParameter
                    //{
                    //    ParameterName = "@Id",
                    //    SqlDbType = SqlDbType.Int,
                    //    Value = 101,
                    //    Direction = ParameterDirection.Input
                    //};
                    //cmd.Parameters.Add(param1);
                    //connection.Open();
                    //SqlDataReader reader = cmd.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    Console.WriteLine(reader["Id"] + ",  " + reader["Name"] + ",  " + reader["Email"] + ",  " + reader["Mobile"]);
                    //}

                    // Stored Procedure with input and output param
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = "spCreateStudent",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Name", "Tran Hiep Quoc");
                    cmd.Parameters.AddWithValue("@Email", "QuocTH@fpt.com");
                    cmd.Parameters.AddWithValue("@Mobile", "0932246230");
                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Id", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Direction = ParameterDirection.Output //Specify the parameter as ouput
                        //No need to specify the value property
                    };
                    cmd.Parameters.Add(outParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Newely Generated Student ID : " + outParameter.Value.ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
