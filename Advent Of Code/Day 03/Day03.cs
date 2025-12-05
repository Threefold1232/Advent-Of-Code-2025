using System;
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
