using System;
using System.Collections.Generic;
using System.Linq;

namespace Posts;

public class Tag
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

public class PostService
{
    public const int MaxPageSize = 100;
    private readonly IPostRepository db;

    public PostService(IPostRepository db)
    {
        this.db = db;
    }

    private IList<Tag> toListTrimmed(byte numberOfItems,
      IQueryable<Tag> query)
    {
        return query.Take(numberOfItems).ToList();
    }

    public IList<Tag> GetTrendingTags(byte numberOfItems)
    {
        return toListTrimmed(numberOfItems, db.GetTrendingTagTable());
    }

    public IList<Tag> GetTrendingTagsByTitle(
      byte numberOfItems)
    {
        return toListTrimmed(numberOfItems, db.GetTrendingTagTable()
          .OrderBy(p => p.Title));
    }

    public IList<Tag> GetYesterdaysTrendingTags(byte numberOfItems)
    {
        return toListTrimmed(numberOfItems,
          db.GetYesterdaysTrendingTagTable());
    }

    public IList<Tag> GetTrendingTags(byte numberOfItems,
  bool sortByTitle)
    {
        var query = db.GetTrendingTagTable();
        if (sortByTitle)
        {
            query = query.OrderBy(p => p.Title);
        }
        return query.Take(numberOfItems).ToList();
    }

    public IList<Tag> GetTrendingTags(byte numberOfItems,
      bool sortByTitle, bool yesterdaysTags)
    {
        var query = yesterdaysTags
          ? db.GetTrendingTagTable()
          : db.GetYesterdaysTrendingTagTable();
        if (sortByTitle)
        {
            query = query.OrderBy(p => p.Title);
        }
        return query.Take(numberOfItems).ToList();
    }

    public Tag GetTagDetails(byte numberOfItems, int index)
    {
        if (index >= numberOfItems)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfItems));
        }
        return GetTrendingTags(numberOfItems)[index];
    }
}