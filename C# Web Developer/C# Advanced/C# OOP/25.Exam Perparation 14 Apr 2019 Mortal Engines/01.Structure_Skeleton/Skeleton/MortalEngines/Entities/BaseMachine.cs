using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private readonly IList<string> targets;

        private BaseMachine()
        {
            this.targets = new List<string>();
        }

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints) 
            : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), $"Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException($"Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => healthPoints;

            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get => attackPoints;

            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get => defensePoints;

            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException($"Target cannot be null");
            }

            var diff = this.AttackPoints - target.DefensePoints;

            target.HealthPoints -= diff;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var targetsOutput = this.targets.Count > 0 ? string.Join(",", this.targets) : "None";

            sb.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:F2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}")
                .AppendLine($" *Targets: {targetsOutput}");

            return sb.ToString().TrimEnd();
        }
    }
}