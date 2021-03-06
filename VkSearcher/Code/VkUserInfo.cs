﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace VkSearcher.Code
{
    public class VkUserInfo
    {
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
