using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shirokov.Nsudotnet.Calendar
{
    class Calendar
    {
        private static void writeHeader()
        {
            Console.WriteLine("+--------------------+");
            Console.Write("|      ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Calendar");
            Console.ResetColor();
            Console.WriteLine("      |");
            Console.WriteLine("+--------------------+");
        }
        private static void writeDaysOfWeek()
        {
            DateTime now = DateTime.Today;
            now = now.AddDays(-(int)now.DayOfWeek + 1);
            for (int i = 0; i < 7; i++)
            {
                if ((int)now.DayOfWeek == 0 || (int)now.DayOfWeek == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(now.ToString("ddd"));
                Console.ResetColor();
                if (i != 6)
                {
                    Console.Write(" ");
                }
                now = now.AddDays(1);
            }
      
        }
       public static void writeCalendar(DateTime userDate)
        {
           DateTime startDate = userDate.AddDays(-((int)userDate.Day + (int)userDate.DayOfWeek) + 2);
          
           writeHeader();
            
           Console.Write("|");
           writeDaysOfWeek();
           Console.WriteLine("|");

            int workingDays = 0;
            while (startDate.Month <= userDate.Month)
            {
                Console.Write("|");
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

                        if (startDate.Day < 10)
                        {
                            Console.Write(" "+startDate.Day);
                        }
                        else
                        {
                            Console.Write(startDate.Day);
                        }
                        Console.ResetColor();

                    }
                    if (i != 6)
                    {
                        Console.Write(" ");
                    }

                    startDate = startDate.AddDays(1);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+--------------------+");
            Console.WriteLine("Working days: {0}", workingDays);
        }
    }
}
