using System;

namespace CinemaTickets
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string type = string.Empty;
            double hallCap = 0.0;
            double student = 0;
            double standart = 0;
            double kid = 0;
            double totalTickets = 0;
            double tickets = 0;
            double studentPer = 0.0;
            double standartPer = 0.0;
            double kidPer = 0.0;
            double studentTotal = 0;
            double standartTotal = 0;
            double kidTotal = 0;
            while (movie != "Finish")
            {
                studentTotal += student;
                standartTotal += standart;
                kidTotal += kid;
                totalTickets += tickets;
                student = 0;
                standart = 0;
                kid = 0;
                tickets = 0;
                hallCap = double.Parse(Console.ReadLine());
                type = Console.ReadLine();

                while (type != "End" && tickets < hallCap)
                {
                    if (type == "student")
                    {
                        student++;
                        tickets++;
                    }
                    else if (type == "standard")
                    {
                        standart++;
                        tickets++;
                    }
                    else if (type == "kid")
                    {
                        kid++;
                        tickets++;
                    }
                    if (hallCap > tickets)
                    {
                        type = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                double fullPer = (tickets / hallCap) * 100;
                Console.WriteLine($"{movie} - {fullPer:F2}% full.");
                movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    studentTotal += student;
                    standartTotal += standart;
                    kidTotal += kid;
                    tickets += totalTickets;
                    studentPer = (studentTotal - studentTotal / totalTickets) * 100;
                    standartPer = (standartTotal / totalTickets) * 100;
                    kidPer = (kidTotal / totalTickets) * 100;
                    Console.WriteLine($"Total tickets: {tickets}");
                    Console.WriteLine($"{studentPer:F2}% student tickets.");
                    Console.WriteLine($"{standartPer:F2}% standard tickets.");
                    Console.WriteLine($"{kidPer:F2}% kids tickets.");
                    break;
                }
            }
        }
    }
}
