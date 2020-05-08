using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        Dictionary<int, Person> data;

        private int id = -1;

        public int Count => this.data.Count;

        public Repository()
        {
            data = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            data.Add(++id, person);
        }

        public Person Get(int id)
        {
            foreach (var p in data)
            {
                if (p.Key == id)
                {
                    return p.Value;
                }
            }

            return null;
        }

        public bool Update(int id, Person newPerson)
        {
            foreach (var person in data)
            {
                if (person.Key == id)
                {
                    data[id] = newPerson;
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            foreach (var person in data)
            {
                if (person.Key == id)
                {
                    data.Remove(person.Key);
                    return true;
                }
            }

            return false;
        }
    }
}
