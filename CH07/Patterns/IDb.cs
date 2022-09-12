using System.Collections.Generic;

namespace Patterns; 
internal interface IDb {
public IEnumerable<Badge> GetBadges();
public IEnumerable<string> GetVisibleBadgeNames();
}
