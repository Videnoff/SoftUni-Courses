using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace P05.Change_Town_Names_Casing
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var country = Console.ReadLine();

                SqlCommand sqlCommand = new SqlCommand("SELECT t.Name " +
                                                       "FROM Towns as t " +
                                                       "JOIN Countries AS c ON c.Id = t.CountryCode " +
                                                       "WHERE c.Name = @countryName", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@countryName", country);

                var towns = new List<string>();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var town = (string)reader["Name"];
                        towns.Add(town.ToUpper());
                    }
                }

                if (towns.Count != 0)
                {
                    sqlCommand = new SqlCommand("UPDATE Towns " +
                                                "SET Name = UPPER(Name) " +
                                                "WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@countryName", country);

                    var updatedRows = sqlCommand.ExecuteNonQuery();

                    Console.WriteLine($"{updatedRows} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
                else
                {
                    Console.WriteLine($"No town names were affected.");
                }
            }
        }
    }
}
