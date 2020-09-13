using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace P08.Increase_Minion_Age
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var minionsIDs = Console.ReadLine().Split().Select(int.Parse).ToArray();

                foreach (var minionsID in minionsIDs)
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Minions " +
                    "SET[Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name])), Age += 1 " +
                    "WHERE Id = @Id", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Id", minionsID);
                    sqlCommand.ExecuteNonQuery();
                }

                SqlCommand selectSqlCommand = new SqlCommand("SELECT [Name], Age FROM Minions", sqlConnection);

                using (SqlDataReader reader = selectSqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
