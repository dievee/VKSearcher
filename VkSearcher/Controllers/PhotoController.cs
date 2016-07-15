using System.Collections.Generic;
using System.Web.Http;
using VkSearcher.JsonModels;

namespace VkSearcher.Controllers
{
    public class PhotoController : BaseController
    {

        [HttpGet]
        public List<UserPhoto> Likes(string friendsId, string targetUserId) //+
        {

            var albumInfo = GetAlbums(targetUserId);
            var photoInfo = GetPhoto(albumInfo, targetUserId);
            var likes = GetUsesLike_Photo(photoInfo, friendsId, targetUserId);
            return likes;

        }

        //[ActionName("liked1")]
        //public List<UserPhoto> Get(string frienwwwedsId, string targetUweserId)
        //{

        //    var albumInfo = GetAlbums(targetUserId);
        //    var photoInfo = GetPhoto(albumInfo, targetUserId);
        //    var likes = GetUsesLike_Photo(photoInfo, friendsId, targetUserId);
        //    return likes;
        //}
    }
}
