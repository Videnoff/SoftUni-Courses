using System;
using MortalEngines.Core;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager mn = new MachinesManager();

            //mn.HirePilot("Pesho");
            //mn.ManufactureFighter("F1", 100, 200);
            //mn.ManufactureTank("T1", 300, 400);

            //mn.EngageMachine("Pesho", "F1");
            //mn.EngageMachine("Pesho", "T1");

            //Console.WriteLine(mn.PilotReport("Pesho"));

            mn.HirePilot("Smith");
            mn.HirePilot("Stones");
            mn.ManufactureFighter("Boeing", 180, 90);
            mn.ManufactureTank("T-72", 100, 100);
            mn.EngageMachine("Stones", "T-72");
            mn.EngageMachine("Smith", "Boeing");
            mn.AttackMachines("Boeing", "T-72");

            Console.WriteLine(mn.MachineReport("Boeing"));
            Console.WriteLine(mn.MachineReport("T-72"));

            Console.WriteLine(mn.PilotReport($"Smith"));
            Console.WriteLine(mn.PilotReport($"Stones"));
        }
    }
}
