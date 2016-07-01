using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkSearcher.JsonModels.UsersLike
{
    public class LikesData
    {
        [JsonProperty("response")]
        public List<Like> like { get; set; }
    }
}