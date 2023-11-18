using System;
using System.Collections.Generic;
using System.Linq;

namespace Posts;

public class Tag
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
}

public class PostService(IPostRepository db)
{
    public const int MaxPageSize = 100;

    private List<Tag> toListTrimmed(byte numberOfItems,
        IQueryable<Tag> query)
    {
        return [.. query.Take(numberOfItems)];
    }

    public List<Tag> GetTrendingTags(byte numberOfItems)
    {
        return toListTrimmed(numberOfItems, db.GetTrendingTagTable());
    }

    public List<Tag> GetTrendingTagsByTitle(
        byte numberOfItems)
    {
        return toListTrimmed(numberOfItems, db.GetTrendingTagTable()
          .OrderBy(p => p.Title));
    }

    public List<Tag> GetYesterdaysTrendingTags(byte numberOfItems)
    {
        return toListTrimmed(numberOfItems,
          db.GetYesterdaysTrendingTagTable());
    }

    public List<Tag> GetTrendingTags(byte numberOfItems,
        bool sortByTitle)
    {
        var query = db.GetTrendingTagTable();
        if (sortByTitle)
        {
            query = query.OrderBy(p => p.Title);
        }
        return [.. query.Take(numberOfItems)];
    }

    public List<Tag> GetTrendingTags(byte numberOfItems,
        bool sortByTitle, bool yesterdaysTags)
    {
        var query = yesterdaysTags
          ? db.GetTrendingTagTable()
          : db.GetYesterdaysTrendingTagTable();
        if (sortByTitle)
        {
            query = query.OrderBy(p => p.Title);
        }
        return [.. query.Take(numberOfItems)];
    }

    public Tag GetTagDetails(byte numberOfItems, int index)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, numberOfItems);
        return GetTrendingTags(numberOfItems)[index];
    }
}