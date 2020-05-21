using System;
using MXGP.Core.Contracts;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var inputInfo = Console.ReadLine().Split();

                var command = inputInfo[0];

                if (command == "CreateRider")
                {
                    var name = inputInfo[1];

                    championshipController.CreateRider(name);
                }
                else if (command == "CreateMotorcycle")
                {
                    var type = inputInfo[1];
                    var model = inputInfo[2];
                    var hp = int.Parse(inputInfo[3]);

                    championshipController.CreateMotorcycle(type, model, hp);
                }
                else if (command == "AddMotorcycleToRider")
                {
                    var rider = inputInfo[1];
                    var model = inputInfo[2];

                    championshipController.AddMotorcycleToRider(rider, model);
                }
                else if (command == "AddRiderToRace")
                {
                    var raceName = inputInfo[1];
                    var riderName = inputInfo[2];

                    championshipController.AddRiderToRace(raceName, riderName);
                }
                else if (command == "CreateRace")
                {
                    var name = inputInfo[1];
                    var laps = int.Parse(inputInfo[2]);

                    championshipController.CreateRace(name, laps);
                }
                else if (command == "StartRace")
                {
                    var raceName = inputInfo[1];

                    championshipController.StartRace(raceName);
                }
                else if (command == "End")
                {
                    break;
                }
            }
        }
    }
}