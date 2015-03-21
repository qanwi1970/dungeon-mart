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
    /// REST service for items
    /// </summary>
    [RoutePrefix("api/v3.5/item")]
    public class ItemController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemController() : this(new ItemService(new ItemRepository(new DungeonMartContext())))
        {
        }

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Gets the entire item list
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(ItemViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var itemList = await Task.Run(() => _itemService.GetItems());
            return Ok(itemList);
        }

        /// <summary>
        /// Get a single item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}", Name = "GetItemById")]
        [ResponseType(typeof(ItemViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var item = await Task.Run(() => _itemService.GetItemById(id));
            return Ok(item);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(ItemViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]ItemViewModel item)
        {
            var newItem = await Task.Run(() => _itemService.AddItem(item));
            return CreatedAtRoute("GetItemById", new {id = newItem.Id}, newItem);
        }

        /// <summary>
        /// Update and item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(ItemViewModel))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]ItemViewModel item)
        {
            var updatedItem = await Task.Run(() => _itemService.UpdateItem(id, item));
            return Ok(updatedItem);
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await Task.Run(() => _itemService.DeleteItem(id));
            return Ok();
        }

        /// <summary>
        /// Re-seed the item data
        /// </summary>
        /// <returns></returns>
        [Route("0/seed")]
        public async Task<IHttpActionResult> Seed()
        {
            var seedDataPath = HttpContext.Current.Server.MapPath("~/SeedData");
            await Task.Run(() => _itemService.SeedItems(seedDataPath));
            return Ok();
        }
    }
}
