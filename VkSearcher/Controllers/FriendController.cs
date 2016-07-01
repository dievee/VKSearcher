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
using VkSearcher.JsonModels;


namespace VkSearcher.Controllers
{
    public class FriendController : ApiController
    {
        private VkUserInfo vkUserInf;
        private LikeInfo likeInformation;
        public Dictionary<string, User> usersLike;
        public Dictionary<string, bool> likesInfo;
        public Dictionary<string, List<User>> tempDict;
        public List<User> tempList;
        private static System.Timers.Timer aTimer;
        private AutoResetEvent autoEvent;

        protected override void Initialize(HttpControllerContext requestContext)
        {
            vkUserInf = new VkUserInfo();
            likeInformation = new LikeInfo();
            usersLike = new Dictionary<string, User>();
            likesInfo = new Dictionary<string, bool>();
            tempDict = new Dictionary<string, List<User>>();
            tempList = new List<User>();
            autoEvent = new AutoResetEvent(false);
            base.Initialize(requestContext);
        }

        // GET: api/Friends
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Friends/5
        public FriendsData Get(int id)
        {
            string access_token = "e7c520cc53cf2bcb2a675cc8c767de065abebfe15f0913b2b702659124b8409441707b4dac8a8c4e58eaf";
            //string id = "81959312";

            string friends = String.Format("https://api.vk.com/method/friends.get?user_id={0}&order=name&offset=4&filter=all&fields=domain,online&name_case=ins&access_token={1}&v=5.50", id, access_token);
            var friend = vkUserInf.Load(friends);
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
