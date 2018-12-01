using System;
using System.IO;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("The final frequency of one sequence is: {0}", CalculateFrequency("./input.txt"));
            Console.WriteLine("The repeated frequency is: {0}", FindRepeatingFrequency("./input.txt"));
            Console.ReadLine();
        }

        static int FindRepeatingFrequency(string filePath)
        {
            int[] sequence = ReadFileToIntArray(filePath);
            HashSet<int> usedFrequencies = new HashSet<int>();
            int tempFrequency = 0;
            int i = 0;
            while (usedFrequencies.Add(tempFrequency))
            {
                tempFrequency += sequence[i];
                i++;
                if (i >= sequence.Length) { i = 0; }
            }
            return tempFrequency;
        }

        static int CalculateFrequency(string filePath)
        {
            int frequency = 0;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int add = 0;
                        int.TryParse(line.Trim(), out add);
                        frequency += add;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
            return frequency;
        }

        static int[] ReadFileToIntArray(string filePath)
        {
            List<int> result = new List<int>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int number = 0;
                        int.TryParse(line.Trim(), out number);
                        result.Add(number);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return result.ToArray();
        }
    }
}
