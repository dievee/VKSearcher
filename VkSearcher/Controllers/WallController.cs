using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VkSearcher.JsonModels;
using VkSearcher.Managers;

namespace VkSearcher.Controllers
{
    public class WallController : ApiController
    {
        // GET: api/GetWall
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: возвращает информацию о лайках targetUser на стену другу или любому другому пользователю
        [HttpGet]
        public List<UserInfo> Likes(string friendsId, string targetUserId)  //+
        {
            VkManager vkm = new VkManager();

            vkm.tempUser.id = friendsId;
            vkm.tempList.Add(vkm.tempUser);
            var wallDictionary = vkm.GetWallInfo(vkm.tempList);
            var likeDictionary = vkm.GetUsesLike_Wall(wallDictionary, targetUserId);

            return likeDictionary;
        }

        // POST: api/GetWall
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetWall/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetWall/5
        public void Delete(int id)
        {
        }
    }
}
