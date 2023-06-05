using Microsoft.Data.SqlClient;
using System;

namespace ADO_.NET_Transaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=(local); database=BankDB; uid=sa; pwd=quoc1910;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("Update Accounts set balance=balance-500 where accountnumber='Account1'",
                        connection,transaction);
                    cmd.ExecuteNonQuery();
                     cmd = new SqlCommand("Update Accounts set balance=balance+500 where accountnumber='Account2'",
                        connection, transaction);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Transaction commited");
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
            }  
        }
    }
}
