using System;
using System.Collections.Generic;
using System.Linq;
using _03.Shopping_Spree.Models;

namespace _03.Shopping_Spree.Core
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            AddPeople();

            AddProduct();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split().ToArray();

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                try
                {
                    Person person = this.people.First(p => p.Name == personName);
                    Product product = this.products.First(p => p.Name == productName);

                    person.BuyProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void AddProduct()
        {
            string[] productArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < productArgs.Length; i++)
            {
                string[] currProductTokens = productArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currProductTokens[0];
                decimal cost = decimal.Parse(currProductTokens[1]);

                Product product = new Product(name, cost);

                this.products.Add(product);
            }
        }

        private void AddPeople()
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] currPepoleTokens = peopleArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currPepoleTokens[0];
                decimal money = decimal.Parse(currPepoleTokens[1]);

                Person person = new Person(name, money);

                this.people.Add(person);
            }
        }
    }
}