using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VkSearcher.Controllers
{
    public class UserController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return new string[] { "user1", "user2" };
        }

        public string Get(int id)
        {
            return "user_id";
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
