using System;
using Testsbases.InvSqrts;

namespace NUnitTests;

[TestFixtureSource(nameof(TestFixtureSources))]
public class InverseSquareRootTests
{
    private readonly IInvSqrt InvSqrt;

    public InverseSquareRootTests(IInvSqrt invSqrt)
    {
        InvSqrt = invSqrt;
    }

    [SetUp]
    public void SetUp()
    {
    }

    [TestCase(.73, 1.1704114719613057)]
    [TestCase(1.05, 0.9759000729485332)]
    [TestCase(2D, 0.7071067811865476)]
    [TestCase(3D, 0.5773502691896257)]
    [TestCase(5D, 0.4472135954999579)]
    [TestCase(10D, 0.31622776601683794)]
    [TestCase(199D, 0.0708881205008336)]
    public void Test(double x, double expected)
    {
        Assume.That(x, Is.GreaterThan(0));

        var y = InvSqrt.InvSqrt(x);
        Assert.That(y, Is.EqualTo(expected).Within(0.00001).Percent);
        TestContext.WriteLine(y);
        TestContext.WriteLine(expected);
    }

    [Test]
    public void RandomTest([Random(0.01D, 10000D, 10)] double x)
    {
        Assume.That(x, Is.GreaterThan(0));

        var y = InvSqrt.InvSqrt(x);
        var expected = Math.Pow(x, -.5);
        Assert.That(y, Is.EqualTo(expected).Within(0.0000001).Percent);
        TestContext.WriteLine(y);
        TestContext.WriteLine(expected);
    }

    public static object[] TestFixtureSources =
    [
        new SystemMathInvSqrt(),
        new Newton3OffsetFastInvSqrt(),
        new Newton4FastInvSqrt(),
        new Halley2OffsetFastInvSqrt(),
    ];
}
