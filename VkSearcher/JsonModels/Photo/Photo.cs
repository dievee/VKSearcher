using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkSearcher.JsonModels
{
    [JsonObject]
    public class Photo
    {
        [JsonProperty("response")]
        public PhotoItems photoItems { get; set; }
    }
    public class PhotoItems
    {
        [JsonProperty("count")]
        public string count { get; set; }

        [JsonProperty("items")]
        public List<AlbumInfo> albumInfo { get; set; }
    }

    public class AlbumInfo
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("thumb_id")]
        public string thumb_id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("updated")]
        public string updated { get; set; }

        [JsonProperty("size")]
        public string size { get; set; }
    }
}