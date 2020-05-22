using System.Collections.Generic;
using SpaceStation.Core;
using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;

namespace SpaceStation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var astronauts = new List<IAstronaut>();
            var planets = new List<IPlanet>();
            var writer = new Writer();
            var reader = new Reader();
            var planetRepository = new PlanetRepository();
            var astronautRepository = new AstronautRepository();
            var mission = new Mission();


            var controller = new Controller(
                astronauts,
                planets,
                planetRepository,
                astronautRepository,
                mission);

            var engine = new Engine(
                writer,
                reader,
                controller);

            engine.Run();
        }
    }
}
