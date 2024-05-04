using BenchmarkDotNet.Attributes;
using Testsbases.SlidingLadders;

namespace BenchmarkTests;

[SimpleJob]
public class SlidingLadderBenchmark
{
    [Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
        26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45)]
    public int N { get; set; }

    [ParamsSource(nameof(MethodSources))]
    public ISlidingLadder? Method { get; set; }

    [Benchmark]
    public int GetValue() => Method!.GetValue(N);

    public static ISlidingLadder[] MethodSources { get; } =
    [
        new ArrayAccessSlidingLadder(),
        new LoopSlidingLadder(),
        new SwitchSlidingLadder(),
        new RecurrsiveSlidingLadder(),
        new RecurrsiveAggressiveInliningSlidingLadder(),
        new AnalyticMathPowSlidingLadder(),
        new AnalyticLoopPowerSlidingLadder(),
        new AnalyticSquarePowerSlidingLadder(),
    ];
}
