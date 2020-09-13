using System;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P09.Increase_Age_Stored_Procedure
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            var minionId = int.Parse(Console.ReadLine());

            var result = IncreaseMinionAgeById(sqlConnection, minionId);

            Console.WriteLine(result);
        }

        private static object IncreaseMinionAgeById(SqlConnection sqlConnection, int minionId)
        {
            var sb = new StringBuilder();

            string procName = "usp_GetOlder";

            using SqlCommand increaseAgeCommand = new SqlCommand(procName, sqlConnection);

            increaseAgeCommand.CommandType = CommandType.StoredProcedure;
            increaseAgeCommand.Parameters.AddWithValue("@minionId", minionId);

            increaseAgeCommand.ExecuteNonQuery();

            string getMinionInfoQueryText = @"SELECT [Name], Age 
                                        FROM Minions 
                                        WHERE Id = @minionId";

            using SqlCommand getMinionInfoCmd = new SqlCommand(getMinionInfoQueryText, sqlConnection);
            getMinionInfoCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();

            reader.Read();

            string minionName = reader["Name"]?.ToString().Trim();
            string minionAge = reader["Age"]?.ToString().Trim();

            sb.AppendLine($"{minionName} - {minionAge} years old");

            return sb.ToString().TrimEnd();
        }
    }
}
