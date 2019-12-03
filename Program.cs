using System;
using System.Linq;
using System.Reflection;

namespace Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Advent of Coder!");
            var problems = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsInterface && typeof(IProblem).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<IProblem>()
                .OrderBy(x => x.Name);

            foreach (var problem in problems) {
                Console.WriteLine($"{problem.Name}: Part 1 Solution: {problem.SolvePart1()}");
                Console.WriteLine($"{problem.Name}: Part 2 Solution: {problem.SolvePart2()}");
            }
        }
    }
}
