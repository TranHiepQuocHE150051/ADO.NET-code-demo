using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Join_Statement_in_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=(local); database=DemoDB; uid=sa; pwd=quoc1910;Encrypt=False";
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Select p.Name,c.Name from products p join categories c on p.CategoryID=c.Id",
                    CommandType = CommandType.Text,
                    Connection = con
                };
                // use reader

                //using var reader = cmd.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                //        var productName= reader.GetString(0);
                //        var categoryName= reader.GetString(1);
                //        Console.WriteLine("ProductName: " + productName + ",Category Name: " + categoryName);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("No Data");
                //}
                // use data adapter
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine("Product name: "+row[0].ToString()+", Category name: " + row[1].ToString());
                }

            }
        }
    }
}
