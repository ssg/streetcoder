using System;
using System.Collections.Generic;

namespace Patterns;
public class Badge
{
    public string Name;
    public int Level;

    private static ISet<string> visibleBadgeNames = getVisibleBadgeNames();

    public bool IsVisible
    {
        get => visibleBadgeNames.Contains(this.Name);
    }

    private static ISet<string> getVisibleBadgeNames()
    {
        throw new NotImplementedException();
    }
}
