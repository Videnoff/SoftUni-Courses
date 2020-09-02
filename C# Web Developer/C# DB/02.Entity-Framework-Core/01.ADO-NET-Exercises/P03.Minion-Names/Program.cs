using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P03.Minion_Names
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var villainId = int.Parse(Console.ReadLine());

                var result = GetMinionsInfoAboutVillain(sqlConnection, villainId);

                Console.WriteLine(result);
            }
        }

        private static string GetMinionsInfoAboutVillain(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            var villainName = GetVillainName(sqlConnection, villainId);

            if (villainName == null)
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villain: {villainName}");

                var getMinionsInfoQueryText = @"SELECT m.[Name], m.Age FROM Villains AS v
                                                   LEFT JOIN MinionsVillains AS mv
                                                   ON v.Id = mv.VillainId
                                                   LEFT JOIN Minions AS m
                                                   ON mv.MinionId = m.Id
                                                   WHERE v.[Name] = @villainName
                                                   ORDER BY m.[Name]";

                SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionsInfoQueryText, sqlConnection);

                getMinionsInfoCommand.Parameters.AddWithValue("@villainName", villainName);

                using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    var rowNum = 1;

                    while (reader.Read())
                    {
                        var minionName = reader["Name"]?.ToString();
                        var minionAge = reader["Age"]?.ToString();

                        sb.AppendLine($"{rowNum}. {minionName} {minionAge}");

                        rowNum++;
                    }
                }
                else
                {
                    sb.AppendLine("(no minions)");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetVillainName(SqlConnection sqlConnection, int villainId)
        {
            var getVillainNameQueryText = @"SELECT [Name] FROM Villains 
                                                    WHERE Id = @villainId";

            using SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQueryText, sqlConnection);

            getVillainNameCmd.Parameters.AddWithValue("villainId", villainId);

            var villainName = getVillainNameCmd
                .ExecuteScalar()?
                .ToString();

            return villainName;
        }
    }
}
