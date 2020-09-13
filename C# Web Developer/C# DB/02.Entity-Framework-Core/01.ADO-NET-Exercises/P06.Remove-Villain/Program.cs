using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P06.Remove_Villain
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            var villainId = int.Parse(Console.ReadLine());

            var result = RemoveVillainById(sqlConnection, villainId);

            Console.WriteLine(result);
        }

        private static object RemoveVillainById(SqlConnection sqlConnection, int villainId)
        {
            var sb = new StringBuilder();

            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            var getVillainNameQueryText = @"SELECT [Name] 
                                                FROM Villains
                                                WHERE Id = @villainId";

            using SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQueryText, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            getVillainNameCmd.Transaction = sqlTransaction;

            var villainName = getVillainNameCmd.ExecuteScalar()?.ToString();

            if (villainName == null)
            {
                sb.AppendLine($"No such villain was found.");
            }
            else
            {
                try
                {
                    var releaseMinionsQueryText = @"DELETE FROM MinionsVillains
                                                        WHERE VillainId = @villainId";
                    using SqlCommand releaseMinionsCmd = new SqlCommand(releaseMinionsQueryText, sqlConnection);

                    releaseMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

                    releaseMinionsCmd.Transaction = sqlTransaction;

                    var releasedMinionsCount = releaseMinionsCmd.ExecuteNonQuery();

                    var deleteVillainQueryText = @"DELETE FROM Villains
                                                    WHERE Id = @villainId";

                    using SqlCommand deleteVillainCmd = new SqlCommand(deleteVillainQueryText, sqlConnection);

                    deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                    deleteVillainCmd.Transaction = sqlTransaction;

                    deleteVillainCmd.ExecuteNonQuery();

                    sqlTransaction.Commit();

                    sb.AppendLine($"{villainName} was deleted.");
                    sb.AppendLine($"{releasedMinionsCount} minions were released.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);

                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        sb.AppendLine(rollbackEx.Message);
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
