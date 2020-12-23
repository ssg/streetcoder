using System.Linq;

namespace Posts
{
    public interface IPostRepository
    {
        IQueryable<Tag> GetTrendingTagTable();

        IQueryable<Tag> GetYesterdaysTrendingTagTable();
    }
}