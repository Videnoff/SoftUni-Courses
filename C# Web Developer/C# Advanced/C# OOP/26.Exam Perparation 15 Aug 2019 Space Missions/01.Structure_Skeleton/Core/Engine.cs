using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        private readonly IController controller;

        public Engine(IWriter writer, IReader reader, IController controller)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = controller;
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    //if (input[0] == "AddAstronaut")
                    //{

                    //}
                    //else if (input[0] == "AddPlanet")
                    //{

                    //}
                    //else if (input[0] == "RetireAstronaut")
                    //{

                    //}
                    //else if (input[0] == "ExplorePlanet")
                    //{

                    //}
                    //else if(input[0] == "Report")
                    //{

                    //}

                    var message = this.ExecuteCommand(input);

                    this.writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private string ExecuteCommand(string[] input)
        {
            var message = string.Empty;

            var commandName = input[0];

            if (commandName == "AddAstronaut")
            {
                var astronautType = input[1];
                var astronautName = input[2];

                message = this.controller.AddAstronaut(astronautType, astronautName);
            }
            else if (commandName == "AddPlanet")
            {
                var planetName = input[1];
                var items = input
                    .Skip(2)
                    .ToArray();

                message = this.controller.AddPlanet(planetName, items);
            }
            else if (commandName == "RetireAstronaut")
            {
                var astronautName = input[1];

                message = this.controller.RetireAstronaut(astronautName);
            }
            else if (commandName == "ExplorePlanet")
            {
                var planetName = input[1];

                message = this.controller.ExplorePlanet(planetName);
            }
            else if (commandName == "Report")
            {
                message = this.controller.Report();
            }

            return message;
        }
    }
}
