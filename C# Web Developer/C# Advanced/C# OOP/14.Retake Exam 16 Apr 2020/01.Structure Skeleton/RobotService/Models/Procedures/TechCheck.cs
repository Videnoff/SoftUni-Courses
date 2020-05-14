using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        private const int TechEnergyToRemove = 8;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.Energy -= TechEnergyToRemove;

            if (robot.IsChecked)
            {
                robot.Energy -= TechEnergyToRemove;
            }

            robot.ProcedureTime -= procedureTime;
        }
    }
}