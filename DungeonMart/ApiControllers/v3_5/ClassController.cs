using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Repositories;
using DungeonMart.Models;
using DungeonMart.Services;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v3_5
{
    /// <summary>
    /// Rest service for character classes
    /// </summary>
    [RoutePrefix("api/v3.5/class")]
    public class ClassController : ApiController
    {
        private readonly ICharacterClassService _characterClassService;

        public ClassController(ICharacterClassService characterClassService)
        {
            _characterClassService = characterClassService;
        }

        // Don't judge. Real DI is coming...
        public ClassController()
            : this(new CharacterClassService(new CharacterClassRepository(new DungeonMartContext())))
        {
        }

        /// <summary>
        /// Gets all the character classes
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(CharacterClassViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var classes = await Task.Run(() => _characterClassService.GetClasses());
            return Ok(classes);
        }

        /// <summary>
        /// Gets a single character class
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetClassById")]
        [ResponseType(typeof(CharacterClassViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var characterClass = await Task.Run(() => _characterClassService.GetClassById(id));
            return Ok(characterClass);
        }

        /// <summary>
        /// Adds a new character class
        /// </summary>
        /// <param name="characterClass"></param>
        [Route("")]
        [ResponseType(typeof(CharacterClassViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]CharacterClassViewModel characterClass)
        {
            var newCharacterClass = await Task.Run(() => _characterClassService.AddClass(characterClass));
            return CreatedAtRoute("GetClassById", new {id = newCharacterClass.Id}, newCharacterClass);
        }

        /// <summary>
        /// Updates a character class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterClass"></param>
        [Route("{id}")]
        [ResponseType(typeof(CharacterClassViewModel))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]CharacterClassViewModel characterClass)
        {
            var updatedCharacterClass = await Task.Run(() => _characterClassService.UpdateClass(id, characterClass));
            return Ok(updatedCharacterClass);
        }

        /// <summary>
        /// Deletes a character class
        /// </summary>
        /// <param name="id"></param>
        [Route("{id}")]
        [ResponseType(typeof(CharacterClassViewModel))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _characterClassService.DeleteClass(id));
            return Ok();
        }

        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _characterClassService.SeedClass(seedDataPath));
            return Ok();
        }
    }
}
