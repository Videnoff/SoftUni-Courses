using System;
using System.Linq;
using _03.Telephony.Contracts;
using _03.Telephony.Exceptions;
using _03.Telephony.Models;

namespace _03.Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        public Engine(IReader reader, IWriter writer) 
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split().ToArray();
            string[] sites = reader.ReadLine().Split().ToArray();

            CallNumbers(phoneNumbers);

            BrowseSites(sites);
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(site));
                }
                catch (InvalidUrlException e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}