using System;

namespace Advent_Of_Code.Day_01
{
    public class Day01
    {
        private int _dialStart = 50;

        private string _inputPath = Path.Combine(AppContext.BaseDirectory, "Day 01", "input.txt");

        public void Run()
        {
            var _rotations = ReadFile(_inputPath);
            Console.WriteLine("Input lines: " + _rotations.Count);
            int answerPartOne = GetPassword(_rotations);
            Console.WriteLine($"The Answer for Part One is: {answerPartOne}");
            int answerPartTwo = GetNewPassword(_rotations);
            Console.WriteLine($"The Answer for Part Two is: {answerPartTwo}");
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
            int dial = _dialStart;

            foreach (string rotation in rotations)
            {
                char direction = char.Parse(rotation.Substring(0, 1));
                int amount = int.Parse(rotation.Substring(1, rotation.Length - 1));


                if (direction == 'L')
                {
                    dial = (dial - amount) % 100;
                    if (dial == 0) _zeros++;
                    continue;
                } 
                else if (direction == 'R')
                {
                    dial = (dial + amount) % 100;
                    if (dial == 0) _zeros++;
                    continue;
                }
            }

            return _zeros;
        }

        private int GetNewPassword(List<string> rotations)
        {
            int clicks = 0;
            int dial = _dialStart;

            foreach (string rotation in rotations)
            {
                char direction = char.Parse(rotation.Substring(0, 1));
                int amount = int.Parse(rotation.Substring(1, rotation.Length - 1));


                if (direction == 'L')
                {
                    int newDial = dial - amount;
                    int oldFloor = (int)Math.Floor((dial - 1) / 100.0);
                    int newFloor = (int)Math.Floor((newDial - 1) / 100.0);
                    clicks += Math.Abs(oldFloor - newFloor);
                    dial = newDial;
                    continue;
                } 
                else if (direction == 'R')
                {
                    int newDial = dial + amount;
                    int oldFloor = (int)Math.Floor(dial /100.0);
                    int newFloor = (int)Math.Floor(newDial / 100.0);
                    clicks += Math.Abs(oldFloor - newFloor);
                    dial = newDial;
                    continue;
                }
            }

            return clicks;
        }
    }
}
