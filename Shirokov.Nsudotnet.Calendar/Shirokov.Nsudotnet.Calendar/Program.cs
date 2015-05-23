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

          Calendar.writeCalendar(userDate);
          Console.ReadKey();
        }
    }
}
