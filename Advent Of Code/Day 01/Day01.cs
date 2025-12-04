using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_Of_Code.Day_01
{
    public class Day01
    {
        public void Run()
        {
            var input = ReadFile(ResolveInputPath());
            Console.WriteLine("Input lines: " + input.Count);
        }

        private static string ResolveInputPath()
        {
            var candidates = new[]
            {
                Path.Combine(AppContext.BaseDirectory, "Day 01", "input.txt"),
            };

            foreach (var path in candidates)
            {
                var full = Path.GetFullPath(path);
                if (File.Exists(full))
                {
                    return full;
                }
            }

            // Fall back to first candidate to surface a consistent not-found message
            return Path.GetFullPath(candidates[0]);
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
