using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace P07.Print_All_Minion_Names
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            var minions = new List<string>();
            var arrangedMinions = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT [Name] FROM Minions", sqlConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader["Name"]);
                    }
                }
            }

            while (minions.Count > 0)
            {
                arrangedMinions.Add(minions[0]);
                minions.RemoveAt(0);

                if (minions.Count > 0)
                {
                    arrangedMinions.Add(minions[minions.Count - 1]);
                    minions.RemoveAt(minions.Count - 1);
                }
            }

            arrangedMinions.ForEach(m => Console.WriteLine(m));
        }
    }
}
