namespace Advent
{
    public interface IProblem {
        string Name { get; }
        int SolvePart1();
        int SolvePart2();
    }
}
