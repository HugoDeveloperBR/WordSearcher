using BenchmarkDotNet.Attributes;
using WordSearcher.App.Core;

namespace WordSearcher.Tests.Performance;

[MemoryDiagnoser]
public class TestBenchmark
{
    private const string Word = "hugo.developer";

    [Benchmark]
    public void Simple()
    {
        ISearcher searcher = new SimpleSearcher();
        searcher.GetHitCount(Word);
    }

    [Benchmark]
    public void RegularExpression()
    {
        ISearcher searcher = new RegularExpressionSearcher();
        searcher.GetHitCount(Word);
    }
}