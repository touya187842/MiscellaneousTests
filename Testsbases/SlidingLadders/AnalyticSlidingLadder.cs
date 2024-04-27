namespace Testsbases.SlidingLadders;

public abstract class AnalyticSlidingLadder : ISlidingLadder
{
    /// <summary>
    /// (1 + sqrt(5))/2
    /// </summary>
    protected const double φ = 1.6180339887498949D;

    /// <summary>
    /// (1 - sqrt(5))/2
    /// </summary>
    protected const double ψ = -0.6180339887498949D;

    /// <summary>
    /// 1 / sqrt(5)
    /// </summary>
    protected const double J = 0.44721359549995793D;

    public abstract int GetValue(int n);
}
