using BenchmarkDotNet.Attributes;
using System;
using Testsbases.InvSqrts;

namespace BenchmarkTests
{
    [SimpleJob]
    public class InverseSquareRootBenchmark
    {
        private const int SEED = 277359;
        private const int COUNT = 100;
        private double[]? Samples;

        [ParamsSource(nameof(MethodSources))]
        public IInvSqrt? Method { get; set; }

        [Benchmark]
        public void Calculate()
        {
            for (int i = 0; i < COUNT; i++)
            {
                _ = Method!.InvSqrt(Samples![i]);
            }
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(SEED);
            Samples = new double[COUNT];
            for (int i = 0; i < COUNT; i++)
            {
                Samples[i] = (1D - random.NextDouble()) * 10000D;
            }
        }

        public static IInvSqrt[] MethodSources { get; } =
        [
            new SystemMathInvSqrt(),
            new Newton3OffsetFastInvSqrt(),
            new Newton4FastInvSqrt(),
            new Halley2OffsetFastInvSqrt(),
    ];
    }
}
