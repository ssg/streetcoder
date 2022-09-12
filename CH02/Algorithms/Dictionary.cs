namespace Algorithms;

public class Birthdate
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }

    public override int GetHashCode()
    {
        return 4; // chosen by a fair dice roll
    }
}