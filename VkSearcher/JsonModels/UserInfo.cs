using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkSearcher.JsonModels
{
    public class UserInfo
    {
        public string owner_id { get; set; }
        public string item_id { get; set; }

        public UserInfo(string owner_Id, string item_id)
        {
            this.owner_id = owner_Id;
            this.item_id = item_id;
        }
    }
}