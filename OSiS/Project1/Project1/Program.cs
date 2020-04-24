using System;
using System.Collections.Generic;
using System.IO;

namespace Project1
{
    class Program
    {
        static void WriteResult(string resultFile, List<string> allFiles)
        {
            var resultText = new List<string>();
            foreach (string file in allFiles)
            {
                resultText.AddRange(File.ReadAllLines(file));

            }
            File.WriteAllLines(resultFile, resultText);
        }

        static string[] SearchFiles(string path, string pattern)
        {
            string[] resultSearch = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            return resultSearch;
        }

        static List<string> FoundFiles(string[] res, string pathForSearch, string fileName)
        {
            string pattern = "*" + fileName + "*" + "*.txt";
            string printRes = "On disk " + pathForSearch + " founded :\n";
            string[] filesList = Directory.GetFiles(pathForSearch, pattern);
            List<string> allFiles = new List<string>();
            foreach (string file in filesList)
            {
                printRes += file + "\n";
                allFiles.Add(file);
            }

            foreach (string folder in res)
            {
                try
                {
                    string[] files = SearchFiles(folder, pattern);
                    foreach (string file in files)
                    {
                        printRes += file + "\n";
                        allFiles.Add(file);
                    }
                }
                catch
                {
                    Console.WriteLine("Error access: " + folder);
                }
            }
            Console.WriteLine(printRes);
            return allFiles;
        }
        static void Main()
        {
            string read = Console.ReadLine();
            Console.WriteLine(@"Start searching on D:\\");
            string pathForSearch = @"D:\\Osis";
            string resultFile = "C:\\result.txt";
            string[] res = Directory.GetDirectories(pathForSearch);
            List<string> allFiles = FoundFiles(res, pathForSearch, read);
            WriteResult(resultFile, allFiles);

        }
    }
}
