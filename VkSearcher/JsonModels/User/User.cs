﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace VkSearcher.JsonModels
{
    public class User
    {
        [JsonProperty("first_name")]
        public string first_name { get; set; }

        [JsonProperty("last_name")]
        public string last_name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("photo_50")]
        public string photo_50 { get; set; }

        [JsonProperty("photo_max")]
        public string photo_max { get; set; }

        [JsonProperty("online")]
        public string online { get; set; }
    }
}