using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        Garage garage = new Garage();

        private readonly IDictionary<string, IRobot> robots = new Dictionary<string, IRobot>();

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, happiness, energy, procedureTime);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRobotType, robotType);
            }

            if (robot.Happiness <= 0 || robot.Happiness > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHappiness);
            }

            if (robot.Energy <= 0 || robot.Happiness > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidEnergy);
            }

            //if (Garage.Capacity < garage.Robots.Count + 1)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            //}

            if (robots.ContainsKey(name))
            {
                throw new ArgumentException(ExceptionMessages.ExistingRobot, nameof(robot));
            }

            robots.Add(name, robot);

            return $"Robot {name} registered successfully";
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }


            return $"{robotName} had chip procedure";

        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            TechCheck(robotName, procedureTime);

            return $"{robotName} had tech check procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            Rest(robotName, procedureTime);

            return $"{robotName} had rest procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            Work(robotName, procedureTime);

            return $"{robotName} was working for {procedureTime} hours";
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            Charge(robotName, procedureTime);

            return $"{robotName} had charge procedure";
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            Polish(robotName, procedureTime);

            return $"{robotName} had polish procedure";
        }

        public string Sell(string robotName, string ownerName)
        {

            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            Sell(robotName, ownerName);

            return $"{ownerName} bought robot with chip";
        }

        public string History(string procedureType)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{procedureType}");

            return sb.ToString().TrimEnd();
        }
    }
}