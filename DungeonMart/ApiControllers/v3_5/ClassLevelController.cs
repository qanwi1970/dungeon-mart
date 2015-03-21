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
    /// Provides character class level progression tables
    /// </summary>
    [RoutePrefix("api/v3.5/classlevel")]
    public class ClassLevelController : ApiController
    {
        private readonly IClassLevelService _classLevelService;

        public ClassLevelController()
            : this(new ClassLevelService(new ClassProgressionRepository(new DungeonMartContext())))
        {
        }

        public ClassLevelController(IClassLevelService classLevelService)
        {
            _classLevelService = classLevelService;
        }

        /// <summary>
        /// Returns all the class level table information
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(ClassLevelViewModel))]
        // GET: api/ClassLevel
        public async Task<IHttpActionResult> Get()
        {
            var classLevels = await Task.Run(() => _classLevelService.GetClassLevels());
            return Ok(classLevels);
        }

        /// <summary>
        /// Get a class and level table row by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetClassLevelById")]
        [ResponseType(typeof(ClassLevelViewModel))]
        // GET: api/ClassLevel/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var classLevel = await Task.Run(() => _classLevelService.GetClassLevelById(id));
            return Ok(classLevel);
        }

        /// <summary>
        /// Add a class level row
        /// </summary>
        /// <param name="classLevel"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(ClassLevelViewModel))]
        // POST: api/ClassLevel
        public async Task<IHttpActionResult> Post([FromBody]ClassLevelViewModel classLevel)
        {
            var addedClassLevel = await Task.Run(() => _classLevelService.AddClassLevel(classLevel));
            return CreatedAtRoute("GetClassLevelById", new {id = addedClassLevel.Id}, addedClassLevel);
        }

        /// <summary>
        /// Updates a class level row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classLevel"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(ClassLevelViewModel))]
        // PUT: api/ClassLevel/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]ClassLevelViewModel classLevel)
        {
            var updatedClassLevel = await Task.Run(() => _classLevelService.UpdateClassLevel(id, classLevel));
            return Ok(updatedClassLevel);
        }

        /// <summary>
        /// Deletes a class level row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        // DELETE: api/ClassLevel/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _classLevelService.DeleteClassLevel(id));
            return Ok();
        }

        /// <summary>
        /// Re-seeds the base SRD class level tables
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _classLevelService.SeedClassLevel(seedDataPath));
            return Ok();
        }
    }
}
