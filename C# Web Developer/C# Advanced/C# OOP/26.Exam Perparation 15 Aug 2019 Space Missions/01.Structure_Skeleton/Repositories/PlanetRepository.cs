using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.ToList().AsReadOnly();

        public void Add(IPlanet model) => this.planets.Add(model);

        public bool Remove(IPlanet model) => this.planets.Remove(model);

        public IPlanet FindByName(string name) => this.planets.FirstOrDefault(p => p.Name == name);
    }
}