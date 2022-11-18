using BenchmarkDotNet.Running;

namespace WordSearcher.Tests.Performance;

internal static class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<TestBenchmark>();
        Console.ReadKey();
    }
}