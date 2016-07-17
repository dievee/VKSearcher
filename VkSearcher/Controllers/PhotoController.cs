using System.Collections.Generic;
using System.Web.Http;
using VkSearcher.JsonModels;
using VkSearcher.Managers;

namespace VkSearcher.Controllers
{
    public class PhotoController : ApiController
    {

       // [HttpGet]
        public List<UserPhoto> GetLikes(string friendsId, string targetUserId) //+
        {
            VkManager vkm = new VkManager();

            //var albumInfo = vkm.GetAlbums(targetUserId);
            //var photoInfo = vkm.GetPhoto(albumInfo, targetUserId);
            //var likes = vkm.GetUsesLike_Photo(photoInfo, friendsId, targetUserId);

            //return likes;

            var albumInfo = vkm.GetAlbums(targetUserId);
            albumInfo.photoItems.albumInfo.Remove(albumInfo.photoItems.albumInfo[1]);
            albumInfo.photoItems.albumInfo.Remove(albumInfo.photoItems.albumInfo[1]);
            var photoInfo = vkm.GetPhoto(albumInfo, targetUserId);
            var likes = vkm.GetUsesLike_Photo(photoInfo, friendsId, targetUserId);

            return likes;
        }




        //[HttpGet]
        //public string Likes(string friendsId)  
        //{

        //    return "successs";
        //}

        [HttpPost]
        public string PostLikes([FromBody]string value)  //, string targetUserId     List<UserPhoto>
        {

            return "successs";
        }

        [HttpGet]
        public string Posts(string postid)  //, string targetUserId     List<UserPhoto>
        {

            return "successs";
        }
    }
}
