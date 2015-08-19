using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//To read from configuration file
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
namespace arWordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;
            var appSettings = ConfigurationManager.AppSettings;
            //if re-write setting was not found; it will not delete the exisiting content before writing new content.
            string rewriteFile = appSettings["rewrite"] ?? "0";
            string storePath = appSettings["storePath"] ?? "0";
            string fileName = appSettings["fileName"] ?? "0";
            string sourceFilePath = appSettings["sourceFilePath"] ?? "0";
            string sourceFileName = appSettings["sourceFileName"] ?? "0";



            if (storePath == "0" || fileName == "0" || sourceFilePath == "0" || sourceFileName == "0")
            {
                Console.WriteLine("Issue with paths [Check Configuration File]......");
            }
            else 
            {
                string words = string.Empty;
                System.IO.StreamReader fileSource = new System.IO.StreamReader(sourceFilePath+ sourceFileName);               
                words = File.ReadAllText(sourceFilePath + sourceFileName);
                words = words.Replace(",", "");               
                   
                Regex regex = new Regex("\\w+");

                    var frequencyList = regex.Matches(words)
                        .Cast<Match>()
                        .Select(c => c.Value.ToLowerInvariant())
                        .GroupBy(c => c)
                        .Select(g => new { Word = g.Key, Count = g.Count() })
                        .OrderByDescending(g => g.Count)
                        .ThenBy(g => g.Word);

                    //To dictionary
                    Dictionary<string, int> dict = frequencyList.ToDictionary(d => d.Word, d => d.Count);
            
                    //If rewriting file is enabled this will clear the file content before adding new data
                    if (rewriteFile == "1")
                    {
                        System.IO.File.WriteAllText(storePath+fileName, string.Empty);
                    }

                    //write frequencies to file.
                    foreach (var item in frequencyList)
                    {
                        // the "true" here enables appending to file.
                        using (System.IO.StreamWriter fileDestination = new System.IO.StreamWriter(storePath+fileName, true))
                        {
                            fileDestination.WriteLine((String.Format("{0}, {1}", item.Word, item.Count)));
                        }
                
                        Console.WriteLine(String.Format("{0}, {1}", item.Word, item.Count));
                    } 
                 
            }
             
            Console.WriteLine("Finished Processing File");
            Console.ReadLine();
        }
    }

}
