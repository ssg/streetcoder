using System.Collections.Generic;
using System.Linq;

namespace Patterns {
  public class User {
    private IDb db;

    public IEnumerable<string> GetBadgeNames() {
      var badges = db.GetBadges();
      foreach (var badge in badges) {
        if (badge.IsVisible) {
          yield return badge.Name;
        }
      }
    }

    public IEnumerable<string> GetBadgesNames2() {
      var badges = db.GetBadges();
      return badges
        .Where(b => b.IsVisible)
        .Select(b => b.Name);
    }
  }
}
