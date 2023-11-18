using System.Collections.Generic;

namespace Patterns;

public interface IDb
{
    public IEnumerable<Badge> GetBadges();
    public IEnumerable<string> GetVisibleBadgeNames();
}
