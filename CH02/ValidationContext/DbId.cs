﻿using System;

public class DbId
{
    public int Value { get; private set; }

    public DbId(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        Value = id;
    }

    public override string ToString() => Value.ToString();

    public override int GetHashCode() => Value;

    public override bool Equals(object? obj)
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

    public class PostId(int id) : DbId(id)
    {
    }

    public class TopicId(int id) : DbId(id)
    {
    }

    public class UserId(int id) : DbId(id)
    {
    }
}