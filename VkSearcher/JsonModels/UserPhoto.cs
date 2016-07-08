using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VkSearcher.JsonModels
{
    public class UserPhoto
    {
            public string owner_id { get; set; }
            public string item_id { get; set; }
            public string album_id { get; set; }

            public UserPhoto(string owner_Id, string item_id, string album_id)
            {
                this.owner_id = owner_Id;
                this.item_id = item_id;
                this.album_id = album_id;
            }       
    }
}