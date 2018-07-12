﻿using Newtonsoft.Json;

namespace CodeGenerator.Models.Common
{

    public class ReturnType
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "isEntity")]
        public bool IsEntity { get; set; }

        [JsonProperty(PropertyName = "isCollection")]
        public bool IsCollection { get; set; }

        [JsonProperty(PropertyName = "nullable")]
        public bool Nullable { get; set; }
    }

}