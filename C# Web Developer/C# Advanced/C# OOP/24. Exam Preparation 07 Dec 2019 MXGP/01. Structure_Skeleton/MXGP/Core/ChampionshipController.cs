﻿using System;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> riderRepository;
        private readonly IRepository<IMotorcycle> motorCycleRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.raceRepository = new RaceRepository();
            this.motorCycleRepository = new MotorcycleRepository();
            this.riderRepository = new RiderRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorCycle = motorCycleRepository.GetByName(model);

            if (motorCycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            switch (type)
            {
                case "Speed":
                    motorCycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorCycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            this.motorCycleRepository.Add(motorCycle);

            return $"{motorCycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);
            this.raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var motorcycle = this.motorCycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);
            

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var riders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();

             sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
             sb.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
             sb.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}