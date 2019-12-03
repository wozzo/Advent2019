using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent.Day2
{
    public class Problem : IProblem
    {
        private enum OpCode
        {
            Add = 1,
            Multiply = 2,
            Halt = 99
        }

        private IList<int> GetInput() => File.ReadAllText("./Day2/input.txt")
                .Split(',')
                .Select(int.Parse)
                .ToList();

        public string Name => "Day 2";

        public int SolvePart1() => RunProgram(12, 2);

        private int RunProgram(int noun, int verb)
        {
            var input = GetInput();
            input[1] = noun;
            input[2] = verb;

            var instructionSetNumber = 0;
            while (true)
            {
                var instructionSet = GetInstructionSet(input, instructionSetNumber);

                switch (instructionSet.OpCode)
                {
                    case OpCode.Add:
                        input[instructionSet.TargetPosition] = instructionSet.Position1Value + instructionSet.Position2Value;
                        break;
                    case OpCode.Multiply:
                        input[instructionSet.TargetPosition] = instructionSet.Position1Value * instructionSet.Position2Value;
                        break;
                    case OpCode.Halt:
                        return input[0];
                }
                instructionSetNumber++;
            }
        }

        private (OpCode OpCode, int Position1Value, int Position2Value, int TargetPosition) GetInstructionSet(IList<int> input, int instructionSet)
        {
            var opCodePosition = instructionSet * 4;
            var opCode = (OpCode)input[opCodePosition];
            if (opCode == OpCode.Halt)
            {
                return (opCode, 0, 0, 0);
            }
            return (opCode, input[input[opCodePosition + 1]], input[input[opCodePosition + 2]], input[opCodePosition + 3]);
        }

        public int SolvePart2()
        {
            const int desiredOutput = 19690720;
            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    try
                    {
                        var result = RunProgram(i, j);
                        if (result == desiredOutput)
                        {
                            return 100 * i + j;
                        }
                    }
                    catch { }
                }
            }

            throw new System.Exception();
        }
    }
}