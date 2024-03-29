﻿using Newtonsoft.Json;

namespace Tools.Modules.Common.MetadataSrv
{

    public class Multiplicity
    {
        [JsonProperty(PropertyName = "multi")]
        public string Multi { get; set; }

        [JsonProperty(PropertyName = "single")]
        public string Single { get; set; }
    }

}