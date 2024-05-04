using System;

namespace Testsbases.SlidingLadders;

public sealed class AnalyticSquarePowerSlidingLadder : AnalyticSlidingLadder
{
    public override int GetValue(int n)
    {
        var u = 1D;
        var v = 1D;
        var phiN = φ;
        var psiN = ψ;
        var p = n + 1;
        while (p > 0)
        {
            if ((p & 1) == 1)
            {
                u *= phiN;
                v *= psiN;
            }
            phiN *= phiN;
            psiN *= psiN;
            p >>= 1;
        }
        return Convert.ToInt32((u - v) * J);
    }
}
