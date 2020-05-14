using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        private const int ChargeHappinessToAdd = 12;
        private const int ChargeEnergyToAdd = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;

            robot.Happiness += ChargeHappinessToAdd;
            robot.Energy += ChargeEnergyToAdd;
        }
    }
}