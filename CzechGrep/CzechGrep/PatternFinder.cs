using System;
using System.Collections.Generic;
using System.IO;

namespace TEST
{
    public class PatternFinder
    {
        private readonly List<List<string>> patterns; // patterns to look for in the lines
        private bool dry;
        private readonly bool offline;
        private readonly bool forceOnline;
        
        public PatternFinder(bool dry, bool offline, bool forceOnline)
        {
            patterns = new List<List<string>>();
            this.dry = dry;
            this.offline = offline;
            this.forceOnline = forceOnline;
        }

        /// <summary>
        /// Gets all patterns for a given word with the help of HtmlParser
        /// </summary>
        /// <param name="word">Word for which the patterns should be searched for</param>
        public void GetAllPatterns(string word)
        {
            if (offline)
            {
                var singleWord = new List<string>();
                singleWord.Add(word);
                patterns.Add(singleWord);
                return;
            }
            
            HtmlParser.DownloadFile(word, forceOnline);
            
            if (HtmlParser.Parse(word, out List<string> forms))
            {
                patterns.Add(forms);
            }
            else
            {
                var singleWord = new List<string>();
                singleWord.Add(word);
                patterns.Add(singleWord);
            }

        }
        /// <summary>
        /// Decides whether the given line contains one of the forms of 1 word
        /// </summary>
        private bool ContainsFormOfWord(List<string> listofWordForms, Line line)
        {
            foreach (var form in listofWordForms)
            {
                if (line.Contains(form)) return true;
            }

            return false;
        }
        /// <summary>
        /// Decides whether the given line contains all of the patterns
        /// </summary>
        private bool ContainsAllPatterns(Line line)
        {
            foreach (var patternList in patterns)
            {
                if (!ContainsFormOfWord(patternList, line)) return false;
            }

            return true;
        }
        /// <summary>
        /// Searches for the patterns in the given file
        /// </summary>
        /// <param name="inputFilePath">Path to the file to search in</param>
        public void FindPatterns(string inputFilePath)
        {
            StreamReader inputReader = new StreamReader(inputFilePath);
            int lineCount = 0;
            var line = new Line(inputReader.ReadLine(), ++lineCount);
            
            
            while (true)
            {
                if (line.IsEmpty())
                {
                    line = new Line(inputReader.ReadLine(), ++lineCount);
                    continue;
                }

                if (ContainsAllPatterns(line))
                    line.Print();
                line = new Line(inputReader.ReadLine(), ++lineCount);
                if (inputReader.EndOfStream) break;
            }
            
        }
        /// <summary>
        /// Only lists the possible forms of the patterns given.
        /// </summary>
        public void DryOption()
        {
            int totalcount = 0;
            
            foreach (var list in patterns)
            {
                Console.WriteLine(list[0] + " has " + list.Count + " variations") ;
                totalcount += list.Count;
                
                foreach (var word in list)
                {
                    Console.WriteLine(word);
                }

            }
            
            Console.WriteLine("total count:" + totalcount);
        }
    }
}