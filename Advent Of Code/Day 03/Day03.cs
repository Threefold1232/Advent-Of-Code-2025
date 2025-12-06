using System;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;

namespace Advent_Of_Code.Day_03
{
    public class Day03
    {
        private string _inputPath = Path.Combine(AppContext.BaseDirectory, "Day 03", "input.txt");

        public void Run()
        {
            var _batteries = ReadFile(_inputPath);
            Console.WriteLine("Input lines: " + _batteries.Count);
            int joltage = GetJoltage(_batteries);
            Console.WriteLine($"Total Joltage Part One: {joltage}");
            long joltagePartTwo = GetJoltagePartTwo(_batteries);
            Console.WriteLine($"Joltage Part Two: {joltagePartTwo}");
        }

        private int GetJoltage(List<string> batteries)
        {
            int totalJoltage = 0;

            foreach (string battery in batteries)
            {
                string number1 = "";
                string number2 = "";

                int max1 = 0;

                for (int i = 0; i < battery.Length - 1; i++)
                {
                    string first = battery[i].ToString();
                    for (int j = i + 1; j < battery.Length; j++)
                    {
                        string second = battery[j].ToString();
                        int candidate = int.Parse(first + second);
                        if (candidate > max1)
                        {
                            max1 = candidate;
                            number1 = first.ToString();
                            number2 = second.ToString();
                        }
                    }
                }

                string joltageString = number1 + number2;
                int joltage = int.Parse(joltageString);
                totalJoltage += joltage;
            }
            return totalJoltage;
        }


        private long GetJoltagePartTwo(List<string> batteries)
        {
            long totalJoltage = 0;

            foreach (string battery in batteries)
            {
                int remove = battery.Length - 12;
                
                List<string> numbers = new List<string>();
                for (int i = 0; i < battery.Length; i++)
                {
                    string number = battery[i].ToString();

                    while (remove > 0 && numbers.Count > 0 && int.Parse(numbers[numbers.Count - 1]) < int.Parse(number))
                    {
                        numbers.RemoveAt(numbers.Count - 1);
                        remove--;
                    }
                    numbers.Add(number);
                }


                while (remove > 0 && numbers.Count > 0)
                {
                    numbers.RemoveAt(numbers.Count - 1);
                    remove--;
                }

                string joltageString = "";
                for (int i = 0; i < 12; i++)
                {
                    joltageString += numbers[i];
                }

                long joltage = long.Parse(joltageString);
                totalJoltage += joltage;
            }
            return totalJoltage;
        }


        private static List<string> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found: " + fileName);
                return new List<string>();
            }

            var lines = File.ReadAllLines(fileName);
            return lines.ToList();
        }
    }
}
