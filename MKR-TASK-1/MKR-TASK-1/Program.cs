using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR_TASK_1
{
     class Program
    {
        delegate string TextOperation(string text);

        static void Main()
        {
            string inputFile = "textPD22.txt";
            string outputFile = "resultPD22.txt";
            File.WriteAllText(outputFile, "");
            ProcessFile(inputFile, outputFile, ToUpperCase);
            ProcessFile(inputFile, outputFile, CountChars);
            ProcessFile(inputFile, outputFile, CountWords);
            Console.WriteLine("готово");
        }
        static void ProcessFile(string input, string output, TextOperation operation)
        {
            string[] lines= File.ReadAllLines(input);
            foreach (string line in lines) 
            {
                string result = operation(line);
                File.AppendAllText(output, result + "\n");
            }

        }
        static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        static string CountChars(string text)
        {
            return $"Chars: {text.Length}";
        }

        static string CountWords(string text)
        {
            int count = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            return $"Words: {count}";
        }
    }
}

