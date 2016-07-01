using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using VkSearcher.Code;
using VkSearcher.Controllers;
using VkSearcher.JsonModels;


namespace VkSearcher.Controllers
{
    public class FriendController : BaseController
    {
        

        // GET: api/Friends
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Friends/5
        public FriendsData Get(int id)
        {
            
            //string id = "81959312";

            string friends = String.Format("https://api.vk.com/method/friends.get?user_id={0}&order=name&offset=4&filter=all&fields=domain,online&name_case=ins&access_token={1}&v=5.50", id, access_token);
            var friend = Load(friends);
            var usersFriends = JsonConvert.DeserializeObject<FriendsData>(friend);

            //var likeDictionary = vkUserInf.GetUsesLike_Wall(wallDictionary);


            return usersFriends;
        }

        // POST: api/Friends
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Friends/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Friends/5
        public void Delete(int id)
        {
        }
    }
}
