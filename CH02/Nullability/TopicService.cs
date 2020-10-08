using System;

public interface IDatabase
{
    bool UpdateEntryTopics(TopicId sourceTopic, TopicId destinationTopic);

    bool IsAlreadyMoved(TopicId from);
}

public interface IUser
{
    bool Authorized(string role);
}

public class TopicService
{
    private IDatabase db;
    private IUser user;

    public MoveResult MoveContents(TopicId from, TopicId to)
    {
        if (from is null)
        {
            throw new ArgumentNullException(nameof(from));
        }
        if (to is null)
        {
            throw new ArgumentNullException(nameof(to));
        }
        if (!user.Authorized("move_contents"))
        {
            return MoveResult.Unauthorized;
        }
        if (db.IsAlreadyMoved(from))
        {
            return MoveResult.AlreadyMoved;
        }
        if (db.UpdateEntryTopics(from, to))
        {
            return MoveResult.Success;
        }
        return MoveResult.AlreadyMoved;
    }

#nullable enable

    public MoveResult MoveContentsNullRef(TopicId from, TopicId to)
    {
        if (db.IsAlreadyMoved(from))
        {
            return MoveResult.AlreadyMoved;
        }
        if (db.UpdateEntryTopics(from, to))
        {
            return MoveResult.Success;
        }
        return MoveResult.AlreadyMoved;
    }

    public void Test()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        _ = MoveContentsNullRef(null, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

#nullable restore
}