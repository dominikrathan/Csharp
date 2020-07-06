using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TEST
{
    public static class HtmlParser
    {
        private static readonly string PathToData = Path.Combine(Directory.GetCurrentDirectory(), "DATA");
        /// <summary>
        /// Downloads the HTML file from http://prirucka.ujc.cas.cz for a given word
        /// containing all of the forms of the given word
        /// </summary>
        /// <param name="word">Word to search for in the dictionary</param>
        /// <param name="forceOnline">Force re-downloading the file if already present</param>
        /// <returns>True if the file was obtained successfully</returns>
        public static bool DownloadFile(string word, bool forceOnline)
        {

            var pathToFile = Path.Combine(PathToData, word + ".html");
            if (!forceOnline && File.Exists(pathToFile)) return true;

            if (word == null)
            {
                return false;
            }

            string baseUrl = "http://prirucka.ujc.cas.cz/?slovo= ";
            string url = baseUrl + word;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, pathToFile);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Parse the HTML file to obtain just the forms of the given word
        /// </summary>
        /// <param name="wordName">The word to search for</param>
        /// <param name="forms">Forms of the given word obtained from the file</param>
        /// <returns>True if the parsing was successful</returns>
        public static bool Parse(string wordName, out List<string> forms)
        {

            var pathToFile = Path.Combine(PathToData, wordName + ".html");
            StreamReader reader = new StreamReader(pathToFile);
            forms = new List<string>();
            forms.Add(wordName);

            // looking for the table

            string line = reader.ReadLine();
            while (!reader.EndOfStream && line != null)
            {
                if (line.Contains("table")) break;
                line = reader.ReadLine();
            }

            if (reader.EndOfStream || line == null) return false;

            // checking that the table is in the right form 

            line = reader.ReadLine();

            if (line == null || !line.Contains("jednotné číslo")) return false;

            // obtaining the words

            line = reader.ReadLine();
            while (!line.Contains("</table>"))
            {
                string zarazka = "<td class=\"centrovane\"";
                string following = line;
                
                while (following.Contains(zarazka))
                {
                    following = following.GetAfter(zarazka);
                    following = following.GetAfter(">");

                    while (following.StartsWith("<"))
                    {
                        following = following.GetAfter(">");
                    }

                    string word = following.GetBefore("<");
                    following = following.GetAfter("<");

                    if (word.Contains(","))
                    {
                        string[] words = word.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                        foreach (var w in words)
                        {
                            if (!forms.Contains(w)) forms.Add(w);
                        }
                    }

                    else if (!forms.Contains(word)) forms.Add(word);
                }

                line = reader.ReadLine();
            }

            return true;
        }
    }
}