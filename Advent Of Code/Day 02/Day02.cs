using System;

namespace Advent_Of_Code.Day_02
{
    public class Day02
    {
        private string _inputPath = Path.Combine(AppContext.BaseDirectory, "Day 02", "input.txt");

        public void Run()
        {
            var _rotations = ReadFile(_inputPath);
            Console.WriteLine("Input lines: " + _rotations.Count);
    
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
