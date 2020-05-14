using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        private const int WorkEnergyDecrement = 6;
        private const int WorkHappinessToAdd = 12;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

            robot.Energy -= WorkEnergyDecrement;
            robot.Happiness += WorkHappinessToAdd;
        }
    }
}