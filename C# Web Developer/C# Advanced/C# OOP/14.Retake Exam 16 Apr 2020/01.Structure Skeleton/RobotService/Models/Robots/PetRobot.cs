using System.Text;

namespace RobotService.Models.Robots
{
    public class PetRobot : Robot
    {
        public PetRobot(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}");

            return sb.ToString().TrimEnd();
        }
    }
}