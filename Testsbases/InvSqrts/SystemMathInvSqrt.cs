using System;

namespace Testsbases.InvSqrts;

public sealed class SystemMathInvSqrt : IInvSqrt
{
    public double InvSqrt(double x) => Math.Pow(x, -0.5);

    public override string? ToString() => nameof(SystemMathInvSqrt);
}
