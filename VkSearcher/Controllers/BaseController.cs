using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Script.Serialization;
using VkSearcher.JsonModels;

namespace VkSearcher.Controllers
{
    public class BaseController : ApiController
    {
        protected string access_token = "e7c520cc53cf2bcb2a675cc8c767de065abebfe15f0913b2b702659124b8409441707b4dac8a8c4e58eaf";

        //private VkUserInfo vkUserInf;
        private BaseController vkUserInf;
        private LikeInfo likeInformation;
        public Dictionary<string, User> usersLike;
        public Dictionary<string, bool> likesInfo;
        public Dictionary<string, List<User>> tempDict;
        public List<User> tempList;
        //  private static System.Timers.Timer aTimer;
       // private AutoResetEvent autoEvent;

        protected override void Initialize(HttpControllerContext requestContext)
        {
            //vkUserInf = new VkUserInfo();
            vkUserInf = new BaseController();
            likeInformation = new LikeInfo();
            usersLike = new Dictionary<string, User>();
            likesInfo = new Dictionary<string, bool>();
            tempDict = new Dictionary<string, List<User>>();
            tempList = new List<User>();
         //   autoEvent = new AutoResetEvent(false);
            base.Initialize(requestContext);
        }


        private static string GetUserInfoUri = "https://api.vk.com/method/users.get?uids={0}&fields=photo_100,status";
        public JObject GetUserInfo()
        {
            var request = string.Format(GetUserInfoUri, 81959312);
            WebClient webClient = new WebClient();
            string response = webClient.DownloadString(request);
            return JObject.Parse(response);
        }

        public static string Load(string address)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var request = WebRequest.Create(address) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public T DeserializeJson<T>(string input)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }

        public string JsonEdit(string jsonstring) // редактирует Json строку убираю из нее все false, (возникают из-за того, что запрос делаеться на забаненого или удаленного пользователя)
        {
            string output = null;
            if (jsonstring.Contains("false,"))
            {
                output = jsonstring.Replace("false,", "");
                return JsonEdit(output);
            }

            if (jsonstring.Contains(",false"))
            {
                output = jsonstring.Replace(",false", "");
                return JsonEdit(output);
            }
            else return jsonstring;
        }
    }
}
