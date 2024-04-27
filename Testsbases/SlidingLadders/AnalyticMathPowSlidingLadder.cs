using System;

namespace Testsbases.SlidingLadders;

public sealed class AnalyticMathPowSlidingLadder : AnalyticSlidingLadder
{
    public override int GetValue(int n)
        => Convert.ToInt32((Math.Pow(φ, n + 1) - Math.Pow(ψ, n + 1)) * J);
}
