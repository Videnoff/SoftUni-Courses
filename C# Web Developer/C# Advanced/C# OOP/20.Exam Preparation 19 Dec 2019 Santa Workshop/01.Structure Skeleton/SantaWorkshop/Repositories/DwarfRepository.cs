using System.Collections.Generic;
using System.Linq;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> dwarfs;

        public DwarfRepository()
        {
            this.dwarfs = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.dwarfs.ToList();

        public void Add(IDwarf model)
        {
            this.dwarfs.Add(model);
        }

        public bool Remove(IDwarf model) => this.dwarfs.Remove(model);

        public IDwarf FindByName(string name) => this.dwarfs.FirstOrDefault(d => d.Name == name);
    }
}