using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VkSearcher.JsonModels;

namespace VkSearcher.JsonModels.UsersLike
{
    [JsonObject]
    public class Like
    {
        [JsonProperty("count")]
        public string count { get; set; }
        [JsonProperty("items")]
        public List<User> items { get; set; }
    }
}