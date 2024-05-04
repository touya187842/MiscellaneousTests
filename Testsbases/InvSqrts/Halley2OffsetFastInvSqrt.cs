namespace Testsbases.InvSqrts;

public sealed class Halley2OffsetFastInvSqrt : FastInvSqrt
{
    private const long OFFSET = 0x5FE74FB9D55D92A7;

    public override double InvSqrt(double x)
    {
        var v = OFFSET - (Cast<double, long>(x) >> 1);
        var y = Cast<long, double>(v);
        var xy2 = x * y * y;
        y *= (3D + xy2) / (1D + 3D * xy2);
        xy2 = x * y * y;
        y *= (3D + xy2) / (1D + 3D * xy2);
        return y;
    }

    public override string? ToString() => nameof(Halley2OffsetFastInvSqrt);
}
