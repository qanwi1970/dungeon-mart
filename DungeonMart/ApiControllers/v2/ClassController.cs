using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DungeonMart.Models;

namespace DungeonMart.ApiControllers.v2
{
    /// <summary>
    /// Rest service for character classes
    /// </summary>
    [RoutePrefix("api/v2/class")]
    public class ClassController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        /// <summary>
        /// Gets a single character class
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok("value");
        }

        /// <summary>
        /// Adds a new character class
        /// </summary>
        /// <param name="characterClass"></param>
        public async Task<IHttpActionResult> Post([FromBody]CharacterClass characterClass)
        {
            return Ok();
        }

        /// <summary>
        /// Updates a character class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterClass"></param>
        public async Task<IHttpActionResult> Put(int id, [FromBody]CharacterClass characterClass)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes a character class
        /// </summary>
        /// <param name="id"></param>
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
