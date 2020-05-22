using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IList<IAstronaut> astronauts;
        private readonly IList<IPlanet> planets;
        private readonly PlanetRepository planetRepository;
        private readonly AstronautRepository astronautRepository;
        private readonly IMission mission;

        private int exploredPlanetsCount;

        public Controller(IList<IAstronaut> astronauts,IList<IPlanet> planets,  PlanetRepository planetRepository, AstronautRepository astronautRepository, IMission mission)
        {
            this.astronauts = astronauts;
            this.planets = planets;
            this.planetRepository = planetRepository;
            this.astronautRepository = astronautRepository;
            this.mission = mission;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if(type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException($"Astronaut type doesn't exists!");
            }

            this.astronauts.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepository.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planetRepository.FindByName(planetName);

            var astronaut = this.astronautRepository.Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException($"You need at least one astronaut to explore the planet");
            }

            this.mission.Explore(planet, astronauts);
            this.exploredPlanetsCount++;

            var deadAstronauts = astronauts.Count(x => !x.CanBreath);

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"{astronaut}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}