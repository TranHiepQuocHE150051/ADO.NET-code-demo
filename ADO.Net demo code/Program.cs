using Microsoft.Data.SqlClient;
using System;
using System.Data;


namespace ADO.Net_demo_code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String connectionString = "server=(local); database=DemoDB; uid=sa; pwd=quoc1910;Encrypt=False";
            var connection = new SqlConnection(connectionString);
            connection.StatisticsEnabled = true;
            connection.FireInfoMessageEventOnUserErrors = true;
            connection.StateChange += (object sender, StateChangeEventArgs e) => {
                Console.WriteLine($"Current state: {e.CurrentState}, Previous state: " + $"{e.OriginalState}");
            };
            connection.Open();
            // CRUD ...
            // Read data
            //using var command = new SqlCommand();
            //command.Connection = connection;

            //string queryString = "SELECT id,name,quantity FROM Products where id = @ID";
            //command.CommandText = queryString;
            //command.Parameters.AddWithValue("@ID", 3);

            //using var reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        var id = reader.GetInt32(0);
            //        var name = reader.GetString("name");
            //        var quantity = reader.GetInt32("quantity");

            //        Console.WriteLine("ID: " + id + ",Name: " + name + ",Quantity: " + quantity);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No data");
            //}
            // Insert data , example executeScalar
            //using var command = new SqlCommand();
            //command.Connection = connection;

            //string queryString = @"INSERT INTO Products  VALUES (@Name, @Quantity);
            //           SELECT CAST(scope_identity() AS int)";


            //command.CommandText = queryString;
            //command.Parameters.AddWithValue("@Name", "Realme Note 8");
            //command.Parameters.AddWithValue("@Quantity", 15);


            //var ProductID = command.ExecuteScalar();//execute, return the first column of the first row
            //Console.WriteLine("New Product, ID = "+ProductID);
            // Delete/Update data , example executeNonQuery
            using var command = new SqlCommand();
            command.Connection = connection;
            string queryString = @"DELETE Products WHERE id = @ProductID";

            command.CommandText = queryString;
            command.Parameters.AddWithValue("@ProductID", 8);

            var rows_affected = command.ExecuteNonQuery();
            Console.WriteLine($"Number of affected lines = {rows_affected} ");


            connection.Close();
        }
    }
}
