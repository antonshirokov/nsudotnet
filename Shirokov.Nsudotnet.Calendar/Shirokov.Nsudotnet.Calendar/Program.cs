using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shirokov.Nsudotnet.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date:");
            string userDateStr = Console.ReadLine();

            DateTime userDate;
            if (!DateTime.TryParse(userDateStr, out userDate))
            {
                Console.WriteLine("Error: unknown date");
                return;
            }

           DateTime startDate = userDate.AddDays(-((int)userDate.Day + (int)userDate.DayOfWeek) + 2);
            for (int i = 0; i < 7; i++)
            {
                if ((int)startDate.DayOfWeek == 0 || (int)startDate.DayOfWeek == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(startDate.ToString("ddd "));
                Console.ResetColor();
                startDate = startDate.AddDays(1);
            }
            startDate = startDate.AddDays(-7);
            Console.WriteLine();

            int workingDays = 0;
            while (startDate.Month <= userDate.Month)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (startDate.Month != userDate.Month)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        if ((int) startDate.DayOfWeek == 0 || (int) startDate.DayOfWeek == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            workingDays++;
                        }
                  
                        if (startDate == userDate)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (DateTime.Today == startDate)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }

                        Console.Write(startDate.ToString("dd"));
                        Console.ResetColor();
                        
                    }
                    Console.Write(" ");
                    startDate = startDate.AddDays(1);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Working days: {0}",workingDays);
            Console.ReadKey();
        }
    }
}
