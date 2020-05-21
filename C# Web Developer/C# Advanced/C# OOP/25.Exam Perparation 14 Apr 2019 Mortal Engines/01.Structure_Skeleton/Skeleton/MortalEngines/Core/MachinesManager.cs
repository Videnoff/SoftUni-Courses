using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.machines = new List<IMachine>();
            this.pilots = new List<IPilot>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            var pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            var tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(f => f.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            var fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attackMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            var defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilotToReport = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilotToReport == null)
            {
                return $"Pilot {pilotReporting} could not be found";
            }

            return pilotToReport.Report();
        }

        public string MachineReport(string machineName)
        {
            var machineToReport = this.machines.FirstOrDefault(m => m.Name == machineName);

            if (machineToReport == null)
            {
                return $"Machine {machineName} could not be found";
            }

            return machineToReport.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var machine = this.machines.FirstOrDefault(f => f.Name == fighterName);

            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            IFighter fighter = (IFighter)machine;

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var machine = this.machines.FirstOrDefault(m => m.Name == tankName);

            if (machine == null)
            {
                return $"Machine {tankName} could not be found";
            }

            ITank tank = (ITank)machine;
            tank.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}