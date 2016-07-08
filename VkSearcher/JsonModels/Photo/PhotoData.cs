using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkSearcher.JsonModels
{
    [JsonObject]
    public class PhotoData
    {
        [JsonProperty("response")]
        public Info info { get; set; }
    }

    public class Info
    {
        [JsonProperty("count")]
        public string count { get; set; }

        [JsonProperty("items")]
        public List<PhotoInfo> photoInfo { get; set; }
    }

    public class PhotoInfo
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("album_id")]
        public string album_id { get; set; }

        [JsonProperty("owner_id")]
        public string owner_id { get; set; }

        [JsonProperty("photo_75")]
        public string photo_75 { get; set; }

        [JsonProperty("photo_130")]
        public string photo_130 { get; set; }

        [JsonProperty("photo_604")]
        public string photo_604 { get; set; }

        [JsonProperty("photo_807")]
        public string photo_807 { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }
}