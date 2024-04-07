using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace BenchmarkTests;

[SimpleJob]
public class SlidingLadderBenchmark
{
    [Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
        26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45)]
    public int N { get; set; }

    [Benchmark]
    public int ArrayAccess() => Steps[N];

    private static readonly int[] Steps = [
        1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946,
        17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578,
        5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296,
        433494437, 701408733, 1134903170, 1836311903];

    [Benchmark]
    public int Switch()
        => N switch
        {
            1 => 1,
            2 => 2,
            3 => 3,
            4 => 5,
            5 => 8,
            6 => 13,
            7 => 21,
            8 => 34,
            9 => 55,
            10 => 89,
            11 => 144,
            12 => 233,
            13 => 377,
            14 => 610,
            15 => 987,
            16 => 1597,
            17 => 2584,
            18 => 4181,
            19 => 6765,
            20 => 10946,
            21 => 17711,
            22 => 28657,
            23 => 46368,
            24 => 75025,
            25 => 121393,
            26 => 196418,
            27 => 317811,
            28 => 514229,
            29 => 832040,
            30 => 1346269,
            31 => 2178309,
            32 => 3524578,
            33 => 5702887,
            34 => 9227465,
            35 => 14930352,
            36 => 24157817,
            37 => 39088169,
            38 => 63245986,
            39 => 102334155,
            40 => 165580141,
            41 => 267914296,
            42 => 433494437,
            43 => 701408733,
            44 => 1134903170,
            45 => 1836311903,
            _ => throw new System.Diagnostics.UnreachableException()
        };

    [Benchmark]
    public int Loop()
    {
        int a = 1;
        int b = 1;
        for (int i = 1; i < N; i++)
        {
            (b, a) = (b + a, b);
        }
        return b;
    }

    [Benchmark]
    public int Recurrsive() => PrivateRecurrsive(N);

    private static int PrivateRecurrsive(int n)
        => n > 1
        ? PrivateRecurrsive(n - 1) + PrivateRecurrsive(n - 2)
        : 1;

    [Benchmark]
    public int RecurrsiveAggressiveInlining() => PrivateRecurrsiveAggressiveInlining(N);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int PrivateRecurrsiveAggressiveInlining(int n)
        => n > 1
        ? PrivateRecurrsiveAggressiveInlining(n - 1) + PrivateRecurrsiveAggressiveInlining(n - 2)
        : 1;
}
