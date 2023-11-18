public struct TopicId(int id)
{
    public int Id { get; private set; } = id;
}

partial class ParameterTypes
{
    public static int Move(int from, int to)
    {
        // ... some cryptic code here
        return 0;
    }

    public static int MoveContents(int fromTopicId, int toTopicId)
    {
        // ... some cryptic code here
        return 0;
    }

    public static MoveResult MoveContentsB(int fromTopicId, int toTopicId)
    {
        // ... still quite a code here
        return MoveResult.Success;
    }

    public static MoveResult MoveContentsC(TopicId from, TopicId to)
    {
        // ... still quite a code here
        return MoveResult.Success;
    }
}