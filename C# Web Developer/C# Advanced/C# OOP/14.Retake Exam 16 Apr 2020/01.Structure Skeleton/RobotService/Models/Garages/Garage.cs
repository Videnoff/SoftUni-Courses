using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        public const int Capacity = 10;

        private IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots { get; set; }

        public void Manufacture(IRobot robot)
        {
            if (robots.Count > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else if (this.robots.ContainsKey(nameof(robot)))
            {
                throw new ArgumentException(ExceptionMessages.ExistingRobot, nameof(robot));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            Garage garage = new Garage();

            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, nameof(robotName));
            }

            robots[robotName].Owner = ownerName;
            robots[robotName].IsBought = true;

            robots.Remove(robotName);
        }
    }
}