using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace OrderbyAge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splittedInput = input.Split();
                string name = splittedInput[0];
                string id = splittedInput[1];
                int age = int.Parse(splittedInput[2]);

                Person person = new Person(name, id, age);
                people.Add(person);

                input = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format($"{this.Name} with ID: {this.Id} is {this.Age} years old.");
        }
    }
}
