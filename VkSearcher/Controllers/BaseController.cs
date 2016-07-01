using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Script.Serialization;
using VkSearcher.JsonModels;
using VkSearcher.JsonModels.UsersLike;
using VkSearcher.JsonModels.UsersWall;

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
        protected User tempUser;
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
            tempUser = new User();
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

        public Dictionary<int, WallItems> GetWallInfo(List<User> list) // Возвращает список айдишники записей на стене у друзей целевого пользователя
        {
            int count;
            int length = list.Count;
            int beginPoint = 0;
            int listCounter = 0;
            int maincounter = 0;
            string id = null;
            string param = null;
            string request = null;
            int enumenator = 0;
            int k = 0;
            if (length % 25 != 0) maincounter = length / 25 + 1; // если количество друзей пользователя не кратно 25
            else maincounter = length / 25; // количество друзей пользователя кратно 25

            WallRequest response = new WallRequest();
            Dictionary<int, WallItems> wallsId = new Dictionary<int, WallItems>();

            for (int j = 0; j < maincounter; j++)
            {
                if (length - beginPoint > 25)
                {
                    count = 25;
                    beginPoint += count;
                    for (int i = 0; i < count; i++)
                    {
                        param = null;
                        if (i < 24) param = ",";
                        else param = "";
                        id = id + String.Format("{0}{1}", list[listCounter].id, param);
                        listCounter++;
                    }
                    request = null;
                    request = "var items=[" + id + "];var c = items.length,i = 0,d={},wallInfo=[];while (i<c){d={};d=API.wall.get({owner_id:items[i],count:100});i = i+1;wallInfo.push(d);}return{\"wallInfo\":wallInfo};";
                    response = RequestOnWall(request);
                    id = null;
                    foreach (WallInfo wallinfo in response.wallResponse.wallInfo) //Adding owner and post id to Distionary<PostId,OwnerId>
                    {
                        foreach (WallItems wallItems in response.wallResponse.wallInfo[k].wallItems)
                        {
                            enumenator++;
                            wallsId.Add(enumenator, wallItems);
                        }
                        k++;
                    }
                    //enumenator = 0;
                    k = 0;
                }

                else
                {
                    count = length - beginPoint;
                    for (int i = 0; i < count; i++)
                    {
                        if (i != 24) param = ",";
                        else param = "";
                        id = id + String.Format("{0}{1}", list[listCounter].id, param);
                    }
                    request = "var items=[" + id + "];var c = items.length,i = 0,d={},wallInfo=[];while (i<c){d={};d=API.wall.get({owner_id:items[i],count:100});i = i+1;wallInfo.push(d);}return{\"wallInfo\":wallInfo};";
                    response = RequestOnWall(request);
                    id = null;
                    foreach (WallInfo wallinfo in response.wallResponse.wallInfo)
                    {

                        foreach (WallItems wallItems in response.wallResponse.wallInfo[k].wallItems)
                        {
                            enumenator++;
                            wallsId.Add(enumenator, wallItems);
                        }
                        k++;
                    }
                    k = 0;
                }
            }

            return wallsId;
        }

        public WallRequest RequestOnWall(string request)// делает запрос на стену каждого целевого пользователя
        {
            string access_token = "e7c520cc53cf2bcb2a675cc8c767de065abebfe15f0913b2b702659124b8409441707b4dac8a8c4e58eaf";
            request = HttpUtility.UrlEncode(request);
            string term = String.Format("https://api.vk.com/method/execute?access_token={0}&code={1}&v=5.50", access_token, request);
            var response = Load(term);// После 2 вызова 3 элемент фолсе ИСПРАВИТЬ
            var correctResponse = JsonEdit(response);
            var wallTime = JsonConvert.DeserializeObject<WallRequest>(correctResponse);
            return wallTime;
        }

        public List<UserInfo> GetUsesLike_Wall(Dictionary<int, WallItems> wallitems, string targetUser)
        {
            int length = wallitems.Count;
            int maincounter = 0;
            int beginpoint = 0;
            string owner_id = null;
            string item_id = null;
            string param = null;
            string request = null;
            int count = 0;
            int itemsCounter = 1;
            int loopCounter = 0;
            int idCounter = 1;
            string id = targetUser;

            if (length % 25 != 0) maincounter = length / 25 + 1;
            else maincounter = length / 25;

            LikesData response = null;
            List<UserInfo> finalResponse = new List<UserInfo>();

            for (int i = 0; i < maincounter; i++)
            {
                if (length - beginpoint > 25)
                {
                    count = 25;
                    beginpoint += 25;
                    param = null;
                    for (int z = 1; z < count + 1; z++)
                    {
                        if (z != 25) param = ",";
                        else param = "";
                        owner_id = owner_id + String.Format("{0}{1}", wallitems[itemsCounter].owner_id, param);
                        item_id = item_id + String.Format("{0}{1}", wallitems[itemsCounter].id, param);
                        itemsCounter++;
                    }

                    request = "var count = 25;var owner_id = [" + owner_id + "];var item_id = [" + item_id + "];var i = 0,d=[],likeInfo=[];while (i<count){d = API.likes.getList({type:\"post\",owner_id:owner_id[i],item_id:item_id[i],filter:\"likes\",extended:1,count:0});i = i + 1;likeInfo.push(d);}return likeInfo;";
                    response = LikeRequest(request);
                    if (response.like == null) break;
                    else
                    {
                        foreach (Like like in response.like)
                        {
                            foreach (User user in response.like[loopCounter].items)
                            {
                                if (id == user.id)
                                {
                                    finalResponse.Add(new UserInfo(wallitems[idCounter].owner_id, wallitems[idCounter].id));// Дичь с цыклом
                                }
                                else { continue; }
                            }
                            idCounter++;
                            loopCounter++;
                        }
                        loopCounter = 0;
                    }
                    owner_id = null;
                    item_id = null;
                }

                else
                {
                    count = length - beginpoint;
                    param = null;
                    for (int z = 1; z < count + 1; i++)
                    {
                        z++;
                        if (z != 25) param = ",";
                        else param = "";
                        owner_id = owner_id + String.Format("{0}{1}", wallitems[itemsCounter].owner_id, param);
                        item_id = item_id + String.Format("{0}{1}", wallitems[itemsCounter].id, param);
                        itemsCounter++;
                    }

                    request = "var count = 2;var owner_id = [" + owner_id + "];var item_id = [" + item_id + "];var i = 0,d=[],likeInfo=[];while (i<count){d = API.likes.getList({type:\"post\",owner_id:owner_id[i],item_id:item_id[i],filter:\"likes\",extended:1,count:0});i = i + 1;likeInfo.push(d);}return likeInfo;";
                    response = LikeRequest(request);

                    foreach (Like like in response.like)
                    {
                        foreach (User user in response.like[loopCounter].items)
                        {
                            if (id == user.id)
                            {
                                finalResponse.Add(new UserInfo(wallitems[idCounter].owner_id, wallitems[idCounter].id));

                            }
                            else continue;
                        }
                        idCounter++;
                        loopCounter++;
                    }
                    loopCounter = 1;

                    owner_id = null;
                    item_id = null;
                }
            }
            return finalResponse;
        }

        public LikesData LikeRequest(string request)
        {
            string access_token = "e7c520cc53cf2bcb2a675cc8c767de065abebfe15f0913b2b702659124b8409441707b4dac8a8c4e58eaf";
            request = HttpUtility.UrlEncode(request);
            string term = String.Format("https://api.vk.com/method/execute?access_token={0}&code={1}&v=5.50", access_token, request);
            Thread.Sleep(500);
            var response = Load(term);// После 2 вызова 3 элемент фолсе ИСПРАВИТЬ
            var correctResponse = JsonEdit(response);
            var wallTime = JsonConvert.DeserializeObject<LikesData>(correctResponse);
            return wallTime;
        }
    }
}
