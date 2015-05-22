using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shirokov.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1 && args.Length != 4)
            {
                Console.WriteLine("program [type] (optional:[line comment] [start comment] [end comment])");
                return;
            }
            if (args.Length == 1)
            {
                string result = CountLines(Directory.GetCurrentDirectory(), args[0], "//", "/*", "*/");
                Console.WriteLine(result);
            }
            else if (args.Length == 4)
            {
                
            }
        }

        static string CountLines(string directory, string type, string lineComment, string startComment,
            string endComment)
        {
            string regComments = String.Format("/{0}([\\s\\S]*?){1}/|{2}(.*?)\r?\n",startComment,endComment,lineComment);
     

            Queue<string> directoriesQueue = new Queue<string>();
            directoriesQueue.Enqueue(directory);
            int countFiles = 0;
            int countLines = 0;
            char[] trimChracters = {' ', '\t'};
            while (directoriesQueue.Count != 0)
            {
                string dir = directoriesQueue.Dequeue();
                string[] dirs = Directory.GetDirectories(dir);
                foreach (string s in dirs)
                {
                    directoriesQueue.Enqueue(s);
                }

                string[] files = Directory.GetFiles(dir, type);
                foreach (string file in files)
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            line = line.Trim(trimChracters);
                            line = Regex.Replace(line, regComments, "");
                            if (line.)
                        }
                    }
                }
            }
        }

    }
}
