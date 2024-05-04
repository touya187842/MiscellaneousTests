namespace Testsbases.InvSqrts;

public sealed class Newton3OffsetFastInvSqrt : FastInvSqrt
{
    private const long OFFSET = 0x5FE7477D40000000;

    public override double InvSqrt(double x)
    {
        var half = x * .5D;
        var v = OFFSET - (Cast<double, long>(x) >> 1);
        var y = Cast<long, double>(v);
        y *= (1.5D - (half * y * y));
        y *= (1.5D - (half * y * y));
        y *= (1.5D - (half * y * y));
        return y;
    }

    public override string? ToString() => nameof(Newton3OffsetFastInvSqrt);
}
