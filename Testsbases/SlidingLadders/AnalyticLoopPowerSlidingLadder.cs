namespace Testsbases.SlidingLadders;

public sealed class AnalyticLoopPowerSlidingLadder : AnalyticSlidingLadder
{
    public override int GetValue(int n)
    {
        var u = 1D;
        var v = 1D;
        for (int i = 0; i <= n; i++)
        {
            u *= φ;
            v *= ψ;
        }
        return (int)((u - v) * J);
    }
}
