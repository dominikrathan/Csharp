using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TEST
{
    class Program
    {
        public static void ShowHelp()
        {
            var pathToReadme = Path.Combine(Directory.GetCurrentDirectory(), "README.md");
            var readmeReader = new StreamReader(pathToReadme);
            var readmeText = readmeReader.ReadToEnd();
            Console.WriteLine(readmeText);
        }
        /// <summary>
        /// Entry point of the whole program
        /// Only parses the command line args and executes the right callback
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            bool dry = false;
            bool offline = false;
            bool forceOnline = false;
            int i = 0;
           
           while (i < args.Length && args[i].StartsWith("--"))
           {
                   switch (args[i++])
                   {
                       case "--dry":
                           dry = true;
                           break;
                       case "--offline":
                           offline = true;
                           break;
                       case "--force-online":
                           forceOnline = true;
                           break;
                       case "--help":
                           ShowHelp();
                           break;
                   }
           }

           if (i == args.Length - 1)
           {
               ShowHelp();
               Environment.Exit(1);
           }
           
           PatternFinder patternFinder = new PatternFinder(dry,offline,forceOnline);

           for (int j = i; j < args.Length-1; j++)
           {
               patternFinder.GetAllPatterns(args[j].ToLower());
           }
           
           try
           {
               if (!dry) 
                   patternFinder.FindPatterns(args[^1]);
               else
               {
                   patternFinder.DryOption();
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine("Exception during the reading of the file:" + ex.Message);
               Environment.Exit(1);
           }
           
        }
    }
}