using System;
using Microsoft.Data.SqlClient;

namespace P01.Initial_Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-FSQK3RB;Integrated Security=true"))
            {
                sqlConnection.Open();
                SqlCommand createDB = new SqlCommand("CREATE DATABASE MinionsDB", sqlConnection);
                createDB.ExecuteNonQuery();
            }

            using (var connection = new SqlConnection(@"Server=DESKTOP-FSQK3RB;Database=MinionsDB;Integrated Security=true"))
            {
                connection.Open();

                var tables = ("CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))" + Environment.NewLine + 
                              "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))" + Environment.NewLine +
                              "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))" + Environment.NewLine +
                              "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))" + Environment.NewLine +
                              "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))" + Environment.NewLine +
                              "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))")
                    .Split(Environment.NewLine);

                foreach (var table in tables)
                {
                    SqlCommand createTable = new SqlCommand(table, connection);
                    createTable.ExecuteNonQuery();
                }

                var inserts = ("INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')" + Environment.NewLine +
                               "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)" + Environment.NewLine +
                               "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)" + Environment.NewLine +
                               "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')" + Environment.NewLine +
                               "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)" + Environment.NewLine +
                               "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)")
                    .Split(Environment.NewLine);

                foreach (var insert in inserts)
                {
                    SqlCommand insertQuery = new SqlCommand(insert, connection);
                    insertQuery.ExecuteNonQuery();
                }
            }
        }
    }
}
