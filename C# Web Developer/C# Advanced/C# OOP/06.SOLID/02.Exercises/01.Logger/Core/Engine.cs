using System;
using System.Linq;
using _01.Logger.Core.Contracts;
using _01.Logger.Factories;
using _01.Logger.Models.Contracts;

namespace _01.Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger) 
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string level = inputArgs[0];
                string dateTime = inputArgs[1];
                string message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTime, message, level);

                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}