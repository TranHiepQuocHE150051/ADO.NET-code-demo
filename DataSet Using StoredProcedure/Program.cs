using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataSet_Using_StoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "server=(local); database=EmployeeDB; uid=sa; pwd=quoc1910;Encrypt=False";
                using(SqlConnection connection= new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    SqlCommand sqlCmd = new SqlCommand
                    {
                        CommandText = "spGetEmployeesByAgeDept", //Specifying the Stored Procedure Name
                        CommandType = CommandType.StoredProcedure, //We are going to Execute the command is a Stored Procedure
                        Connection = connection //Specifying the connection object whhere the Stored Procedure is going to be execute
                    };
                    sqlCmd.Parameters.AddWithValue("@Age", 25);
                    sqlCmd.Parameters.AddWithValue("@Dept", "IT");
                    SqlDataAdapter da = new SqlDataAdapter
                    {
                        SelectCommand = sqlCmd
                    };
                    da.Fill(ds);
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Department"]);
                    }
                }
                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
