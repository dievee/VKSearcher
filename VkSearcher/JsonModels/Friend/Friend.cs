using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace VkSearcher.JsonModels
{
    [JsonObject]
    public class Friend
    {
        [JsonProperty("count")]
        public string count { get; set; }

        [JsonProperty("items")]
        public List<User> items { get; set; }
    }
}