using System.Collections.Generic;

namespace Tools.Modules.Common
{
    public class Relation
    {
        public string TableLocal { get; set; }

        public string TableRemote { get; set; }

        public List<string> KeyRemote { get; set; }
    }
}
