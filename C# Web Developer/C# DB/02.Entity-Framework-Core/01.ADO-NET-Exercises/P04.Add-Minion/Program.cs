using System;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P04.Add_Minion
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var minionsInput = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var minionsInfo = minionsInput[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var villainInput = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var villainInfo = villainInput[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var result = AddMinionToDatabase(sqlConnection, minionsInfo, villainInfo);

                Console.WriteLine(result);
            }
        }

        private static object AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainInfo)
        {
            StringBuilder sb = new StringBuilder();

            var minionName = minionsInfo[0];
            var minionAge = minionsInfo[1];
            var minionTown = minionsInfo[2];

            var villainName = villainInfo[0];

            var townId = EnsureTownExists(sqlConnection, minionTown, sb);

            var villainId = EnsureVillainExists(sqlConnection, villainName, sb);

            var insertMinionQueryText = @"INSERT INTO Minions([Name], Age, TownId) 
                                            VALUES (@minionName, @minionAge, @townId)";

            using SqlCommand insertMinionCmd = new SqlCommand(insertMinionQueryText, sqlConnection);

            insertMinionCmd.Parameters.AddRange(new []
            {
                new SqlParameter("@minionName", minionName), 
                new SqlParameter("@minionAge", minionAge), 
                new SqlParameter("@townId", townId) 
            });

            insertMinionCmd.ExecuteNonQuery();

            var getMinionIdQueryText = @"SELECT Id FROM Minions 
                                            WHERE [Name] = @minionName";

            using SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQueryText, sqlConnection);

            getMinionIdCmd.Parameters.AddWithValue(@"minionName", minionName);

            var minionId = getMinionIdCmd.ExecuteScalar().ToString();

            var insertIntoMappingQueryText = @"INSERT INTO MinionsVillains(MinionId, VIllainId) 
                                                VALUES (@minionId, @villainId)";
            using SqlCommand insertIntoMappingCmd = new SqlCommand(insertIntoMappingQueryText, sqlConnection);

            insertIntoMappingCmd.Parameters.AddRange(new []
            {
                new SqlParameter("@minionId", minionId), 
                new SqlParameter("@villainId", villainId) 
            });

            insertIntoMappingCmd.ExecuteNonQuery();

            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return sb.ToString().TrimEnd();
        }

        private static object EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder sb)
        {
            var getVillainIdQueryText = @"SELECT Id 
                                            FROM Villains 
                                            WHERE [Name] = @name";

            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQueryText, sqlConnection);

            getVillainIdCmd.Parameters.AddWithValue("@name", villainName);

            var villainId = getVillainIdCmd.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                var getFactorIdQueryText = @"SELECT Id 
                                                FROM EvilnessFactors 
                                                WHERE [Name] = 'Evil'";

                using SqlCommand getFactorIdCmd = new SqlCommand(getFactorIdQueryText, sqlConnection);

                var factorId = getFactorIdCmd.ExecuteScalar()?.ToString();

                var insertVillainQueryText = @"INSERT INTO Villains ([Name], EvilnessFactorId) 
                                                VALUES (@villainName, @factorId)";

                using SqlCommand insertVillainCmd = new SqlCommand(insertVillainQueryText, sqlConnection);

                insertVillainCmd.Parameters.AddWithValue(@"villainName", villainName);

                insertVillainCmd.Parameters.AddWithValue(@"factorId", factorId);

                insertVillainCmd.ExecuteNonQuery();

                villainId = getVillainIdCmd.ExecuteScalar().ToString();

                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static object EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder sb)
        {
            var getTownIdQueryText = @"SELECT Id FROM Towns 
                                        WHERE [Name] = @townName";

            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQueryText, sqlConnection);

            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            var townId = getTownIdCmd.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                var insertTownQueryText = @"INSERT INTO Towns([Name], CountryCode) 
                                                VALUES (@townName, 1)";
                using SqlCommand insertTownCmd = new SqlCommand(insertTownQueryText, sqlConnection);

                insertTownCmd.Parameters.AddWithValue("townName", minionTown);

                insertTownCmd.ExecuteNonQuery();

                townId = getTownIdCmd.ExecuteScalar().ToString();

                sb.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId;
        }
    }
}
