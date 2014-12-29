using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Service.Interfaces;
using DungeonMart.Shared.Models;
using DungeonMart.Utils;

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
        [ResponseType(typeof(Monster))]
        public IHttpActionResult Get()
        {
            var monsterListResponse = ControllerUtils.ListResponse(Request, _monsterService.GetMonsters());
            return monsterListResponse;
        }

        /// <summary>
        /// Gets a single monster by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(Monster))]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(_monsterService.GetMonsterById(id));
        }

        /// <summary>
        /// Adds a new monster
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Monster))]
        public async Task<IHttpActionResult> Post([FromBody]Monster monster)
        {
            return Ok(_monsterService.AddMonster(monster));
        }

        /// <summary>
        /// Updates a monster
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(Monster))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Monster monster)
        {
            return Ok(_monsterService.UpdateMonster(id, monster));
        }

        /// <summary>
        /// Deletes a monster
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            _monsterService.DeleteMonster(id);
            return Ok();
        }
    }
}
