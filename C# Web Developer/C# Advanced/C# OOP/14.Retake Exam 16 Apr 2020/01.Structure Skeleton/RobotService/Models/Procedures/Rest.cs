using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        private const int RestHappinessDecrement = 3;
        private const int RestEnergyToAdd = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

            robot.Happiness -= RestHappinessDecrement;
            robot.Energy += RestEnergyToAdd;
        }
    }
}