using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v2
{
    [RoutePrefix("api/v2/spell")]
    public class SpellController : ApiController
    {
        private readonly ISpellService _spellService;

        public SpellController(ISpellService spellService)
        {
            _spellService = spellService;
        }

        /// <summary>
        /// Gets all the spells
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(SpellViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var spells = await Task.Run(() => _spellService.GetSpells());
            return Ok(spells);
        }

        /// <summary>
        /// Gets a single spell by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetSpellById")]
        [ResponseType(typeof(SpellViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var spell = await Task.Run(() => _spellService.GetSpellById(id));
            return Ok(spell);
        }

        /// <summary>
        /// Adds a spell
        /// </summary>
        /// <param name="spell"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(SpellViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]SpellViewModel spell)
        {
            var addedSpell = await Task.Run(() => _spellService.AddSpell(spell));
            return CreatedAtRoute("GetSpellById", new {id = addedSpell.Id}, addedSpell);
        }

        /// <summary>
        /// Updates a spell
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spell"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(SpellViewModel))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]SpellViewModel spell)
        {
            var updatedSpell = await Task.Run(() => _spellService.UdpateSpell(id, spell));
            return Ok(updatedSpell);
        }

        /// <summary>
        /// Deletes a spell
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _spellService.DeleteSpell(id));
            return Ok();
        }

        /// <summary>
        /// Seeds the spell table from the json file
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _spellService.SeedSpells(seedDataPath));
            return Ok();
        }
    }
}
