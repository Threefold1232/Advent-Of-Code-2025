using System;

namespace Advent_Of_Code.Day_01
{
    public class Day01
    {
        private int _dial = 50;

        private string _inputPath = Path.Combine(AppContext.BaseDirectory, "Day 01", "input.txt");

        public void Run()
        {
            var _rotations = ReadFile(_inputPath);
            Console.WriteLine("Input lines: " + _rotations.Count);
            int answer = GetPassword(_rotations);
            Console.WriteLine($"The Answer is: {answer}");
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

        private int GetPassword(List<string> rotations)
        {
            int _zeros = 0;

            foreach (string rotation in rotations)
            {
                char direction = char.Parse(rotation.Substring(0, 1));
                int amount = int.Parse(rotation.Substring(1, rotation.Length - 1));


                if (direction == 'L')
                {
                    _dial = (_dial - amount) % 100;
                    if (_dial == 0) _zeros++;
                    continue;
                } 
                else if (direction == 'R')
                {
                    _dial = (_dial + amount) % 100;
                    if (_dial == 0) _zeros++;
                    continue;
                }
            }

            return _zeros;
        }

    }
}
