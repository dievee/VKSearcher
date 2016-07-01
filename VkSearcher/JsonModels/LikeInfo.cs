using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkSearcher.JsonModels
{
    public class LikeInfo
    {
        public Dictionary<string, Dictionary<string, bool>> usersLike { get; set; }
        public Dictionary<string, bool> likesInfo { get; set; }
        public Dictionary<string, List<User>> tempDict { get; set; }
        public List<User> tempList { get; set; }
    }
}