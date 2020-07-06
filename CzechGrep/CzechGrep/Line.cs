using System;

namespace TEST
{
    public class Line
    {
        public string[] Words { get; set; }
        public int LineNumber { get; set; }
        public bool[] Matches { get; set; }

        public Line(string line, int lineNumber)
        {
            Words = line.Split(" ");
            Matches = new bool[Words.Length];
            LineNumber = lineNumber;
        }

        public bool IsEmpty() => (Words == null || Words.Length == 0);

        public bool Contains(string form)
        {
            for (int i = 0; i < Words.Length; i++)
            {
                if (Words[i].Contains(form.ToLower()))
                {
                    Matches[i] = true;
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            Console.Write(LineNumber + " ");
            for (int i = 0; i < Words.Length; i++)
            {
                if (Matches[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    int j = 0;
                    while (j < Words[i].Length && char.IsLetter(Words[i][j]))
                    {
                        Console.Write(Words[i][j]);
                        j++;
                    }
                    Console.ResetColor();
                    
                    if (j < Words[i].Length)
                    {
                        while (j < Words[i].Length)
                        {
                            Console.Write(Words[i][j]);
                            j++;
                        }
                            
                    }
                    Console.Write(" ");

                }
                else
                {
                    Console.Write(Words[i] + " ");
                }
            }
            
            Console.WriteLine();
        }
    }
}