using System;
using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }


        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.ToList().AsReadOnly();

        public void Add(IAstronaut model) => this.astronauts.Add(model);

        public bool Remove(IAstronaut model) => this.astronauts.Remove(model);

        public IAstronaut FindByName(string name) => this.astronauts.FirstOrDefault(a => a.Name == name);
    }
}