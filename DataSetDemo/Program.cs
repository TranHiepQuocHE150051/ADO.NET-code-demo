using System;
using System.Data;

namespace DataSetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            //add collums
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            //add row data
            table.Rows.Add(1, "Quoc", 22);
            table.Rows.Add(2, "Trung", 23);
            table.Rows.Add(3, "Thanh", 21);
            Console.WriteLine($"Table {table.TableName}");
            foreach(DataColumn collum in table.Columns)
            {
                Console.Write($"{collum.ColumnName,20}");
            }
            Console.WriteLine();    
            foreach (DataRow row in table.Rows)
            {
                Console.Write($"{row[0].ToString(),20}");             
                Console.Write($"{row[1].ToString(),20}");       
                Console.Write($"{row[2].ToString(),20}");        
                Console.WriteLine();
            }
            table.Rows[2]["Name"] = "Son";
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                Console.Write($"{row[0].ToString(),20}");
                Console.Write($"{row[1].ToString(),20}");
                Console.Write($"{row[2].ToString(),20}");
                Console.WriteLine();
            }

        }
    }
}
