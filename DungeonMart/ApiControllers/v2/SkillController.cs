using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.ApiControllers.v2
{
    /// <summary>
    /// REST service for skills
    /// </summary>
    [RoutePrefix("api/v2/skill")]
    public class SkillController : ApiController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        /// <summary>
        /// Gets all the skills
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> Get()
        {
            var skills = await Task.Run(() => _skillService.GetSkills());
            return Ok(skills);
        }

        /// <summary>
        /// Get one skill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetSkillById")]
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var skill = await Task.Run(() => _skillService.GetSkillById(id));
            return Ok(skill);
        }

        /// <summary>
        /// Adds a skill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> Post([FromBody]Skill skill)
        {
            var addedSkill = await Task.Run(() => _skillService.AddSkill(skill));
            return CreatedAtRoute("GetSkillById", new {id = addedSkill.Id}, addedSkill);
        }

        /// <summary>
        /// Updates a skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Skill skill)
        {
            var updatedSkill = await Task.Run(() => _skillService.UdpateSkill(id, skill));
            return Ok(updatedSkill);
        }

        /// <summary>
        /// Deletes a skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _skillService.DeleteSkill(id));
            return Ok();
        }

        /// <summary>
        /// Seed the table from the json data
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _skillService.SeedSkills(seedDataPath));
            return Ok();
        }
    }
}
