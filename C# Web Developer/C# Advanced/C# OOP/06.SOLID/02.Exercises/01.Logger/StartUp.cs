using System;
using System.Collections.Generic;
using System.Linq;
using _01.Logger.Core;
using _01.Logger.Core.Contracts;
using _01.Logger.Factories;
using _01.Logger.Models.Contracts;

namespace _01.Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Models.Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];
                string level = "INFO";

                if (appendersArgs.Length == 3)
                {
                    level = appendersArgs[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);

                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
