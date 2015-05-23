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
            string fileType = args[0];
            if (args.Length == 1)
            {
                string result = CountLines(Directory.GetCurrentDirectory(), fileType, "//", "/*", "*/");
                Console.WriteLine(result);
            }
            else if (args.Length == 4)
            {
                string commentLine = args[1];
                string startComment = args[2];
                string endComments = args[3];
                string result = CountLines(Directory.GetCurrentDirectory(), fileType, commentLine, startComment,endComments);
                Console.WriteLine(result);
            }
          //  Console.ReadKey();
        }

        static string CountLines(string directory, string type, string lineComment, string startComment,
            string endComment)
        {
            string startCommentEscaped = Regex.Escape(startComment);
            string endCommentEscaped = Regex.Escape(endComment);

            string regComments = String.Format("{0}(.*){1}|{2}(.*)", startCommentEscaped, endCommentEscaped, Regex.Escape(lineComment));
            string regStartComment = String.Format("{0}(.*)",startCommentEscaped);
            string regEndComment = String.Format("(.*){0}", endCommentEscaped);

            Queue<string> directoriesQueue = new Queue<string>();
            directoriesQueue.Enqueue(directory);
            int countFiles = 0;
            int countLines = 0;
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
                    Console.WriteLine(file);
                    try
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            countFiles++;
                            string line;
                            bool isCommented = false;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (isCommented)
                                {
                                    if (Regex.IsMatch(line, regEndComment))
                                    {
                                        line = Regex.Replace(line, regEndComment, " ");
                                        isCommented = false;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                line = Regex.Replace(line, regComments, " "); 
                                isCommented = Regex.IsMatch(line, regStartComment);
                                if (isCommented)
                                {
                                    line = Regex.Replace(line, regStartComment, " ");
                                }
                               
                                line = line.Trim();
                                
                                if (!String.IsNullOrEmpty(line))
                                {
                                    countLines++;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return String.Format("{0} lines in {1} files",countLines,countFiles);
        }

    }
}
