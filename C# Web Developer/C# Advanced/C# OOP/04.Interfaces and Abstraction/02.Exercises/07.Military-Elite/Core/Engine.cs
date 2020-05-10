using System;
using System.Collections.Generic;
using System.Linq;
using _07.Military_Elite.Contracts;
using _07.Military_Elite.Core.Contracts;
using _07.Military_Elite.Exceptions;
using _07.Military_Elite.IO.Contracts;
using _07.Military_Elite.Models;

namespace _07.Military_Elite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer) 
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(cmdArgs, id, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddGeneral(cmdArgs, id, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        var engineer = CreateEngineer(id, firstName, lastName, salary, corps, cmdArgs);

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException e)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionArgs = cmdArgs.Skip(6).ToArray();

                        GetCommando(missionArgs, commando);

                        soldier = commando;
                    }
                    catch (InvalidCorpsException e)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier AddPrivate(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }

        private static void GetCommando(string[] missionArgs, ICommando commando)
        {
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string missionCodeName = missionArgs[i];
                    string missionState = missionArgs[i + 1];

                    IMission mission = new Mission(missionCodeName, missionState);

                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateException e)
                {
                    continue;
                }
            }
        }

        private static IEngineer CreateEngineer(int id, string firstName, string lastName, decimal salary, string corps,
            string[] cmdArgs)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            string[] repairArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }

            soldier = general;

            return soldier;
        }
    }
}