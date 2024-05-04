namespace Testsbases.SlidingLadders;

public class LoopSlidingLadder : ISlidingLadder
{
    public int GetValue(int n)
    {
        int a = 1;
        int b = 1;
        for (int i = 1; i < n; i++)
        {
            (b, a) = (b + a, b);
        }
        return b;
    }
}
