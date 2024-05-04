using System.Runtime.CompilerServices;

namespace Testsbases.SlidingLadders;

public sealed class RecurrsiveAggressiveInliningSlidingLadder : ISlidingLadder
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetValue(int n)
        => n > 1
        ? GetValue(n - 1) + GetValue(n - 2)
        : 1;
}
