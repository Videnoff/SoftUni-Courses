using System;

namespace WorldSnookerChampionship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string stageOfChampionship = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            char photo = char.Parse(Console.ReadLine());
            double sum = 0.0;
            switch (stageOfChampionship)
            {
                case "Quarter final":
                    switch (ticketType)
                    {
                        case "Standard":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (55.50);
                            }
                            else
                            {
                                sum = ticketsCount * 55.50;
                            }

                            break;
                        case "Premium":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (105.20);
                            }
                            else
                            {
                                sum = ticketsCount * 105.20;
                            }

                            break;
                        case "VIP":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (118.90);
                            }
                            else
                            {
                                sum = ticketsCount * 118.90;
                            }
                            break;
                    }
                    break;
                case "Semi final":
                    switch (ticketType)
                    {
                        case "Standard":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (75.88);
                            }
                            else
                            {
                                sum = ticketsCount * 75.88;
                            }

                            break;
                        case "Premium":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (125.22);
                            }
                            else
                            {
                                sum = ticketsCount * 125.22;
                            }
                            break;
                        case "VIP":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (300.40);
                            }
                            else
                            {
                                sum = ticketsCount * 300.40;
                            }
                            break;
                    }
                    break;
                case "Final":
                    switch (ticketType)
                    {
                        case "Standard":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (110.10);
                            }
                            else
                            {
                                sum = ticketsCount * 110.10;
                            }
                            break;
                        case "Premium":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (160.66);
                            }
                            else
                            {
                                sum = ticketsCount * 160.66;
                            }
                            break;
                        case "VIP":
                            if (photo == 'Y')
                            {
                                sum = ticketsCount * (400.00);
                            }
                            else
                            {
                                sum = ticketsCount * 400.00;
                            }
                            break;
                    }
                    break;
            }

            double discount = 0.0;
            double photoPrice = ticketsCount * 40;

            if (sum > 4000)
            {
                discount = (sum * 25) / 100;
                if (photo == 'Y')
                {
                    sum -= discount;
                }
                else
                {
                    sum -= discount;
                }
            }
            else if (sum > 2500)
            {
                if (photo == 'Y')
                {
                    discount = (sum * 10) / 100;
                    sum = sum - discount + photoPrice;
                }
                else
                {
                    discount = (sum * 10) / 100;
                    sum -= discount;
                }
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
