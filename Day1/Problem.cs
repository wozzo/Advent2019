using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent.Day1
{
    public class Problem : IProblem
    {
        private readonly ICollection<int> input = File
            .ReadAllLines("./Day1/input.txt")
            .Select(int.Parse)
            .ToList();

        public string Name => "Day 1";
        public int SolvePart1() => input
            .Select(GetFuelRequirement)
            .Sum();

        private static int GetFuelRequirement(int mass) => (mass / 3) - 2;

        public int SolvePart2() => input
                .Select(GetTotalFuelRequirement)
                .Sum();

        private static int GetTotalFuelRequirement(int moduleMass) {
            var fuel = Day1.Problem.GetFuelRequirement(moduleMass);
            var cumulativeFuel = 0;
            while (fuel > 0) {
                cumulativeFuel += fuel;
                fuel = Day1.Problem.GetFuelRequirement(fuel);
            }

            return cumulativeFuel;
        }
    }
}