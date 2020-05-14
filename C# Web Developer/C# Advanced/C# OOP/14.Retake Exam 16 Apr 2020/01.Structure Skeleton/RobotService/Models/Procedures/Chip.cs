using System;
using System.Collections.Generic;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int ChipHappinessDecrement = 5;

        protected List<IRobot> chippedRobots;

        public Chip()
        {
            this.chippedRobots = new List<IRobot>();
        }


        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            if (robot.IsChipped)
            {
                throw new ArgumentException(ExceptionMessages.AlreadyChipped, nameof(robot));
            }

            robot.ProcedureTime -= procedureTime;

            robot.Happiness -= ChipHappinessDecrement;


            robot.IsChipped = true;


        }
    }
}