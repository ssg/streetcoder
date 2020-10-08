internal class ProperGetHashCode
{
    public int TopicId { get; set; } // both id's are auto-incrementing
    public int EntryId { get; set; } // only unique per topic, starting at 1 each time

    public override int GetHashCode()
    {
        return (int)(((TopicId & 0xFFFF) << 16)
            ^ (TopicId & 0xFFFF0000 >> 16)
            ^ EntryId);
    }
}