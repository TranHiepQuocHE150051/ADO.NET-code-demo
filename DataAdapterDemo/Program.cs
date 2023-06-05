using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DataAdapterDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                string connectionString = "server=(local); database=StudentDB; uid=sa; pwd=quoc1910;Encrypt=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Student", connection);
                    //DataTable dt = new DataTable();
                    //dataAdapter.Fill(dt);
                    ////The following things are done by the Fill method
                    ////1. Open the connection
                    ////2. Execute Command
                    ////3. Retrieve the Result
                    ////4. Fill/Store the Retrieve Result in the Data table
                    ////5. Close the connection
                    //Console.WriteLine("Using Data Table");
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    //}
                    //Console.WriteLine();

                    //DataSet ds = new DataSet();
                    //dataAdapter.Fill(ds, "student");
                    //Console.WriteLine("Using Data Set");
                    //foreach (DataRow row in ds.Tables["student"].Rows)
                    //{
                    //    //Accessing the data using string Key Name
                    //    Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    //}


                    // Call a procedure with DataAdapter
                    SqlDataAdapter da = new SqlDataAdapter("spGetStudents", connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Console.WriteLine();
                    Console.WriteLine("Stored Procedure with Data Adapter");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
    }
    }
}
