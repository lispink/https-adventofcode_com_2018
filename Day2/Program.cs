using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checksum is: {0}", CalculateCheckSum("./input.txt"));
            Console.WriteLine("Overlapping letters is: {0}", GetOverlappingCharactersOfAlmostEquelIdsFromFile("./input.txt"));
            Console.ReadLine();
        }

        static int CalculateCheckSum(string filePath)
        {
            int doubles = 0;
            int triples = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var letters = line.ToCharArray();
                    var characterCounts = new Dictionary<char, int>();
                    foreach (var letter in letters)
                    {
                        if (!characterCounts.TryAdd(letter, 1))
                        {
                            characterCounts[letter]++;
                        }
                    }
                    if (characterCounts.ContainsValue(2)) { doubles++; }
                    if (characterCounts.ContainsValue(3)) { triples++; }
                }
            }

            return doubles * triples;
        }

        static string GetOverlappingCharactersOfAlmostEquelIdsFromFile(string filePath)
        {
            var result = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                var Ids = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null && string.IsNullOrEmpty(result))
                {
                    result = GetOverlappingCharactersOfAlmostEquelIds(line, Ids);
                    Ids.Add(line);
                }
            }
            return result;
        }

        static string GetOverlappingCharactersOfAlmostEquelIds(string id, IList<string> checkAgainst)
        {
            string result = null;
            foreach (var check in checkAgainst)
            {
                result = GetOverlappingCharactersOfAlmostEquelIds(id, check);
                if (!string.IsNullOrEmpty(result)) { return result; }
            }
            return result;
        }

        static string GetOverlappingCharactersOfAlmostEquelIds(string a, string b)
        {
            int? differenceIndex = null;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (differenceIndex.HasValue)
                    {
                        return null;
                    }
                    else
                    {
                        differenceIndex = i;
                    }
                }
            }
            return differenceIndex.HasValue ? a.Remove(differenceIndex.Value, 1) : null;
        }
    }
}
