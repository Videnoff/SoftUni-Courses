using System;
using Microsoft.Data.SqlClient;

namespace P02.Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true"))
            {
                sqlConnection.Open();
                var select = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
                             "FROM Villains AS v " +
                             "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                             "GROUP BY v.Id, v.Name " +
                             "HAVING COUNT(mv.VillainId) > 3 " +
                             "ORDER BY COUNT(mv.VillainId)";

                SqlCommand command = new SqlCommand(select, sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }
            }
        }
    }
}
