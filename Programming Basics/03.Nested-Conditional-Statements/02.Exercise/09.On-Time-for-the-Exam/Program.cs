using System;

namespace OnTimefortheExam
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMin = int.Parse(Console.ReadLine());

            int examTime = (examHour * 60) + examMin;
            int arriveTime = (arriveHour * 60) + arriveMin;

            int diff = examTime- arriveTime;

            int diffHour = diff / 60;
            int diffMin = diff % 60;

            int h = Math.Abs(diffHour);
            int m = Math.Abs(diffMin);

            if (diff < 0)
            {
                Console.WriteLine("Late");
                if (Math.Abs(diffHour) < 1)
                {
                    Console.WriteLine($"{m} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{h}:{m:D2} hours after the start");
                }
            }
            else if (diff >= 0 && diff <= 30)
            {
                Console.WriteLine("On time");
                if (diffMin != 0)
                {
                    Console.WriteLine($"{m} minutes before the start");
                }
            }
                else
                {
                    Console.WriteLine("Early");
                    if (diffHour < 1)
                    {
                    Console.WriteLine($"{m:D2} minutes before the start");
                    }
                    else
                    {
                    Console.WriteLine($"{h}:{m:D2} hours before the start");
                    }
                }
            }
        }
    }
