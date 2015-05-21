using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shirokov.Nsudotnet.NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] loserMessages =
            {
                "You are looser!",
                "It's hard for you!",
                "Go home!",
                "You will never win!"
            };
            Random random = new Random();
            DateTime start;
            List<string> attempts = new List<string>(1000);

            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            int guessNumber = random.Next(100);

            start = DateTime.Now;
            while (true)
            {
                Console.WriteLine("{0}, guess number from 0 to 100:",name);
                string buff = Console.ReadLine();
                if (buff == "q")
                {
                    Console.WriteLine("Good Bye!");
                    Console.ReadKey();
                    return;
                }
                int userNumber = 0;
                try
                {
                    userNumber = int.Parse(buff);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("{0} you must write a number!",name);
                    continue;
                }

                if (userNumber != guessNumber && attempts.Count%4 == 0 && attempts.Count != 0)
                {
                    Console.WriteLine(loserMessages[random.Next(loserMessages.Length)]);
                }

                if (userNumber > guessNumber)
                {
                    Console.WriteLine("guessing number < {0}",userNumber);
                    attempts.Add(String.Format("{0} < {1}",guessNumber,userNumber));
                }
                else if (userNumber < guessNumber)
                {
                    Console.WriteLine("{0} < guessing number", userNumber);
                    attempts.Add(String.Format("{0} < {1}", userNumber, guessNumber));
                }
                else
                {
                    Console.WriteLine("You win!");
                    TimeSpan timeSpent = DateTime.Now - start;
                    Console.WriteLine("Time spent: {0}",timeSpent);
                    Console.WriteLine("Number of tries: {0}",attempts.Count);
                    foreach (string s in attempts)
                    {
                            Console.WriteLine(s);
                    }
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
