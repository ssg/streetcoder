public struct TopicId
{
    public int Id { get; private set; }

    public TopicId(int id)
    {
        this.Id = id;
    }
}

partial class ParameterTypes
{
    public int Move(int from, int to)
    {
        // ... some cryptic code here
        return 0;
    }

    public int MoveContents(int fromTopicId, int toTopicId)
    {
        // ... some cryptic code here
        return 0;
    }

    public MoveResult MoveContentsB(int fromTopicId, int toTopicId)
    {
        // ... still quite a code here
        return MoveResult.Success;
    }

    public MoveResult MoveContentsC(TopicId from, TopicId to)
    {
        // ... still quite a code here
        return MoveResult.Success;
    }
}