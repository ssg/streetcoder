public class HashCodeTest
{
    public int Halue { get; set; }

    public override bool Equals(object obj) => 
        obj is HashCodeTest test &&
               Halue == test.Halue;

    public override int GetHashCode() => 387336856 + Halue.GetHashCode();
}