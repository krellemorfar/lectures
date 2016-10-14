using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OldschoolMysql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This is \"Oldschool\" MySql fetching using ADO.NET");

            var connStr = "server=localhost;database=northwind;uid=admin;pwd=Fckfck123";
 
            using (var connection = new MySqlConnection(connStr))
            {
                connection.Open();

                var cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM category";

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var id = rdr.GetInt32(0);
                        var name = rdr.GetString(1);
                        Console.WriteLine($"{id} {name}");
                    }
                }
            }
        }
    }
}
