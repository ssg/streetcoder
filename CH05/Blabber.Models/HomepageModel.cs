using System.Collections.Generic;

namespace Blabber
{
    public class HomepageModel
    {
        public BlabForm Form { get; set; }

        public IEnumerable<Blab> Blabs { get; set; }
    }
}