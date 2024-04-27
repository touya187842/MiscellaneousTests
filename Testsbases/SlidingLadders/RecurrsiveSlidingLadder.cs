namespace Testsbases.SlidingLadders;

public sealed class RecurrsiveSlidingLadder : ISlidingLadder
{
    public int GetValue(int n)
        => n > 1
        ? GetValue(n - 1) + GetValue(n - 2)
        : 1;
}
