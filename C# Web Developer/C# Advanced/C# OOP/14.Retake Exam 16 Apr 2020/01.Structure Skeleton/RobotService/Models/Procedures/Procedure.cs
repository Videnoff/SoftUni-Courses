using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private IReadOnlyCollection<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{typeof(Procedure)}");

            foreach (var robot in robots)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IRobot robot, int procedureTime);
    }
}