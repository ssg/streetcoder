﻿using System;

public class DbId : IEquatable<DbId>
{
    public int Value { get; private set; }

    public DbId(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        Value = id;
    }

    public override string ToString() => Value.ToString();

    public override bool Equals(object? obj)
    {
        return Equals(obj as DbId);
    }

    public bool Equals(DbId? other) => other?.Value == Value;

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

public class EntryId(int id) : DbId(id)
{
}

public class TopicId(int id) : DbId(id)
{
}

public class UserId(int id) : DbId(id)
{
}