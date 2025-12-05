using System;
using Microsoft.Win32.SafeHandles;

namespace Advent_Of_Code.Day_02
{
    public class Day02
    {
        private string _inputPath = Path.Combine(AppContext.BaseDirectory, "Day 02", "input.txt");

        public void Run()
        {
            var _ids = ReadFile(_inputPath);
            Console.WriteLine("Input lines: " + _ids.Count);

            long invalidIds = GetInvalidIds(_ids);
            Console.WriteLine($"Invalid IDs: {invalidIds}");

            long invalidIdsPartTwo = GetNewInvalidIds(_ids);
            Console.WriteLine($"Invalid IDs Part 2: {invalidIdsPartTwo}");
        }

        private long GetInvalidIds(List<string> ids)
        {
            long invalid = 0;

            foreach (string id in ids)
            {
                long id1 = long.Parse(id.Split("-")[0]);
                long id2 = long.Parse(id.Split("-")[1]);

                for (long i = id1; i <= id2; i++)
                {
                    string idString = i.ToString();

                    if (idString[0] == '0') continue;

                    string idString1 = idString.Substring(0, idString.Length / 2);
                    string idString2 = idString.Substring(idString.Length / 2);

                    if (idString1.Equals(idString2))
                    {
                        invalid += i;
                    }
                }
            }

            return invalid;
        }

        List<int> numberSequence = new List<int>();
        private long GetNewInvalidIds(List<string> ids)
        {
            long invalid = 0;

            foreach (string id in ids)
            {
                long id1 = long.Parse(id.Split("-")[0]);
                long id2 = long.Parse(id.Split("-")[1]);

                for (long i = id1; i <= id2; i++)
                {
                    string idString = i.ToString();
                    numberSequence.Clear();

                    if (idString[0] == '0') continue;

                    for (int j = 0; j < idString.Length; j++)
                    {
                        int idNumber = idString[j];
                        if (!numberSequence.Contains(idNumber))
                        {
                            numberSequence.Add(idNumber);
                            continue;
                        }
                        else
                        { 
                            try
                            {                                
                                bool matches = true;
                                for (int a = j; a < idString.Length; a += j)
                                {
                                    string sequence1 = idString.Substring(a, j);
                                    string sequence2 = idString.Substring(a - j, j);

                                    if (!sequence1.Equals(sequence2))
                                    {
                                        matches = false;
                                        break;
                                    } 
                                }

                                if (matches)
                                {
                                    invalid += long.Parse(idString);
                                    break;
                                } 
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return invalid;
        }

        private static List<string> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found: " + fileName);
                return new List<string>();
            }

            var content = File.ReadAllText(fileName);
            var parts = content.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            return parts.ToList();
        }
    }
}
