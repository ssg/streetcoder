using System;

public class DbId : IEquatable<DbId>
{
    public int Value { get; private set; }

    public DbId(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }
        Value = id;
    }

    public override string ToString() => Value.ToString();

    public override bool Equals(object obj)
    {
        return Equals(obj as DbId);
    }

    public bool Equals(DbId other) => other?.Value == Value;

    public override int GetHashCode()
    {
        return -1937169414 + Value.GetHashCode();
    }

    public static bool operator ==(DbId a, DbId b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(DbId a, DbId b)
    {
        return !a.Equals(b);
    }
}

public class EntryId : DbId
{
    public EntryId(int id) : base(id)
    {
    }
}

public class TopicId : DbId
{
    public TopicId(int id) : base(id)
    {
    }
}

public class UserId : DbId
{
    public UserId(int id) : base(id)
    {
    }
}