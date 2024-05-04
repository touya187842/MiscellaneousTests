using System.Runtime.CompilerServices;

namespace Testsbases.InvSqrts;

public abstract class FastInvSqrt : IInvSqrt
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private protected static unsafe TTo Cast<TFrom, TTo>(TFrom value)
        where TFrom : struct
        where TTo : struct
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
        => *(TTo*)&value;
#pragma warning restore CS8500

    public abstract double InvSqrt(double x);
}
