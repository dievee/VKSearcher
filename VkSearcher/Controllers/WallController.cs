using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VkSearcher.JsonModels;
using VkSearcher.Controllers;

namespace VkSearcher.Controllers
{
    public class WallController : BaseController
    {
        // GET: api/GetWall
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: возвращает информацию о лайках targetUser на стену другу или любому другому пользователю
        public List<UserInfo> Get(string friendsId, string targetUserId)
        {
            tempUser.id = friendsId;
            tempList.Add(tempUser);
            var wallDictionary = GetWallInfo(tempList);
            var likeDictionary = GetUsesLike_Wall(wallDictionary, targetUserId);

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
