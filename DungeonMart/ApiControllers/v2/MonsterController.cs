using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DungeonMart.ApiControllers.v2
{
    public class MonsterController : ApiController
    {
        // GET: api/Monster
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Monster/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Monster
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Monster/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Monster/5
        public void Delete(int id)
        {
        }
    }
}
