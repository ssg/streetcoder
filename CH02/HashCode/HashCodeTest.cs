public class HashCodeTest
{
    public int Halue { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is HashCodeTest test &&
               Halue == test.Halue;
    }

    public override int GetHashCode()
    {
        return 387336856 + Halue.GetHashCode();
    }
}