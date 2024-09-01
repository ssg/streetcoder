using System;

public class PostId : IEquatable<PostId>
{
    public int Value { get; private set; }

    public PostId(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }
        Value = id;
    }

    public override string ToString() => Value.ToString();

    public override int GetHashCode() => Value;

    public override bool Equals(object obj) => Equals(obj as PostId);

    public bool Equals(PostId other) => other?.Value == Value;

    public static bool operator ==(PostId a, PostId b) => a.Equals(b);

    public static bool operator !=(PostId a, PostId b) => !a.Equals(b);
}