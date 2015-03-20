using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v2
{
    /// <summary>
    /// REST service for Monsters
    /// </summary>
    [RoutePrefix("api/v2/monster")]
    public class MonsterController : ApiController
    {
        private readonly IMonsterService _monsterService;

        /// <summary>
        /// Constructor for injecting services
        /// </summary>
        /// <param name="monsterService"></param>
        public MonsterController(IMonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        /// <summary>
        /// Gets the list of monsters
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(MonsterViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var monsterListResponse = await Task.Run(() => _monsterService.GetMonsters());
            return Ok(monsterListResponse);
        }

        /// <summary>
        /// Gets a single monster by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetMonsterById")]
        [ResponseType(typeof(MonsterViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var monster = await Task.Run(() => _monsterService.GetMonsterById(id));
            return Ok(monster);
        }

        /// <summary>
        /// Adds a new monster
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(MonsterViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]MonsterViewModel monster)
        {
            var addedMonster = await Task.Run(() => _monsterService.AddMonster(monster));
            return CreatedAtRoute("GetMonsterById", new {id = addedMonster.Id}, monster);
        }

        /// <summary>
        /// Updates a monster
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(MonsterViewModel))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]MonsterViewModel monster)
        {
            var updatedMonster = await Task.Run(() => _monsterService.UpdateMonster(id, monster));
            return Ok(updatedMonster);
        }

        /// <summary>
        /// Deletes a monster
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _monsterService.DeleteMonster(id));
            return Ok();
        }

        /// <summary>
        /// Re-seeds the base SRD feat data
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _monsterService.SeedMonster(seedDataPath));
            return Ok();
        }
    }
}
