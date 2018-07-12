using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeGenerator.Modules.Common
{

    public class NavigationProperty
    {
        [JsonProperty(PropertyName = "entityTypeName")]
        public string EntityTypeName { get; set; }

        [JsonProperty(PropertyName = "multiplicity")]
        public string Multiplicity { get; set; }

        [JsonProperty(PropertyName = "keyLocal")]
        public List<string> KeyLocal { get; set; }

        [JsonProperty(PropertyName = "keyRemote")]
        public List<string> KeyRemote { get; set; }
    }

}