using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace VkSearcher.JsonModels.UsersWall
{
    [JsonObject]
    public class WallRequest
    {
        [JsonProperty("response")]
        public WallResponse wallResponse { get; set; }
    }

    public class WallResponse 
    {
        [JsonProperty("wallInfo")]
        public List<WallInfo> wallInfo { get; set; }
    }

    public class WallInfo 
    {
        [JsonProperty("count")]
        public string count { get; set; }
        [JsonProperty("items")]
        public List<WallItems> wallItems { get; set; }
    }

    public class WallItems
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("from_id")]
        public string from_id { get; set; }
        [JsonProperty("owner_id")]
        public string owner_id { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("post_type")]
        public string post_type { get; set; }
    }
}