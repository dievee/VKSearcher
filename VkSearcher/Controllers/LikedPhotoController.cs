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
    public class LikedPhotoController : BaseController  // rename it later  , update routes
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public List<UserPhoto> Get(string friendsId, string targetUserId)
        {

            var albumInfo = GetAlbums(targetUserId);
            var photoInfo = GetPhoto(albumInfo, targetUserId);
            var likes = GetUsesLike_Photo(photoInfo, friendsId, targetUserId);
            return likes;
        }

        // POST: api/GetAlbums
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetAlbums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetAlbums/5
        public void Delete(int id)
        {
        }
    }
}
