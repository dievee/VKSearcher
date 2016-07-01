using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace VkSearcher.JsonModels
{
        //[JsonObject]
        public class FriendsData
        {
            [JsonProperty("response")]
            public Friend friend { get; set; }
        }
}