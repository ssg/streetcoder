using System;

public class DbId
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

    public override int GetHashCode() => Value;

    public override bool Equals(object obj)
    {
        return obj is DbId other && other.Value == Value;
    }

    public static bool operator ==(DbId a, DbId b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(DbId a, DbId b)
    {
        return !a.Equals(b);
    }

    public class PostId : DbId
    {
        public PostId(int id) : base(id)
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
}