using Testsbases.SlidingLadders;

namespace NUnitTests;

[TestFixtureSource(nameof(TestFixtureSources))]
public class SlidingLadderTests
{
    private readonly ISlidingLadder SlidingLadder;

    public SlidingLadderTests(ISlidingLadder slidingLadder)
    {
        SlidingLadder = slidingLadder;
    }

    [SetUp]
    public void SetUp()
    {
    }

    [TestCase(1, ExpectedResult = 1)]
    [TestCase(2, ExpectedResult = 2)]
    [TestCase(3, ExpectedResult = 3)]
    [TestCase(4, ExpectedResult = 5)]
    [TestCase(5, ExpectedResult = 8)]
    [TestCase(6, ExpectedResult = 13)]
    [TestCase(7, ExpectedResult = 21)]
    [TestCase(8, ExpectedResult = 34)]
    [TestCase(9, ExpectedResult = 55)]
    [TestCase(10, ExpectedResult = 89)]
    [TestCase(11, ExpectedResult = 144)]
    [TestCase(12, ExpectedResult = 233)]
    [TestCase(13, ExpectedResult = 377)]
    [TestCase(14, ExpectedResult = 610)]
    [TestCase(15, ExpectedResult = 987)]
    [TestCase(16, ExpectedResult = 1597)]
    [TestCase(17, ExpectedResult = 2584)]
    [TestCase(18, ExpectedResult = 4181)]
    [TestCase(19, ExpectedResult = 6765)]
    [TestCase(20, ExpectedResult = 10946)]
    [TestCase(21, ExpectedResult = 17711)]
    [TestCase(22, ExpectedResult = 28657)]
    [TestCase(23, ExpectedResult = 46368)]
    [TestCase(24, ExpectedResult = 75025)]
    [TestCase(25, ExpectedResult = 121393)]
    [TestCase(26, ExpectedResult = 196418)]
    [TestCase(27, ExpectedResult = 317811)]
    [TestCase(28, ExpectedResult = 514229)]
    [TestCase(29, ExpectedResult = 832040)]
    [TestCase(30, ExpectedResult = 1346269)]
    [TestCase(31, ExpectedResult = 2178309)]
    [TestCase(32, ExpectedResult = 3524578)]
    [TestCase(33, ExpectedResult = 5702887)]
    [TestCase(34, ExpectedResult = 9227465)]
    [TestCase(35, ExpectedResult = 14930352)]
    [TestCase(36, ExpectedResult = 24157817)]
    [TestCase(37, ExpectedResult = 39088169)]
    [TestCase(38, ExpectedResult = 63245986)]
    [TestCase(39, ExpectedResult = 102334155)]
    [TestCase(40, ExpectedResult = 165580141)]
    [TestCase(41, ExpectedResult = 267914296)]
    [TestCase(42, ExpectedResult = 433494437)]
    [TestCase(43, ExpectedResult = 701408733)]
    [TestCase(44, ExpectedResult = 1134903170)]
    [TestCase(45, ExpectedResult = 1836311903)]
    public int Test(int n) => SlidingLadder.GetValue(n);

    public static object[] TestFixtureSources =
    [
        new ArrayAccessSlidingLadder(),
        new LoopSlidingLadder(),
        new SwitchSlidingLadder(),
        new RecurrsiveSlidingLadder(),
        new RecurrsiveAggressiveInliningSlidingLadder(),
        new AnalyticMathPowSlidingLadder(),
        new AnalyticLoopPowerSlidingLadder(),
        new AnalyticSquarePowerSlidingLadder(),
    ]; 
}
