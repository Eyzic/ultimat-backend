using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ultimat.Api.Entities;
using Ultimat.Api.Entities.Requests;
using Ultimat.Api.Services;

namespace Ultimat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _service;

        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }

        // List operations

        /// <summary>
        /// Get a list of all available shopping lists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingList>> GetAllShoppingLists()
        {
            return _service.GetAllLists().ToList();
        }

        /// <summary>
        /// Get a specified shopping list
        /// </summary>
        /// <param name="listId">The id of the shopping list to fetch</param>
        /// <returns></returns>
        [HttpGet("{listId}")]
        public ActionResult<ShoppingListWithItems> GetShoppingList([FromRoute] Guid listId)
        {
            var res = _service.GetList(listId);

            if (res == null)
                return NotFound();

            return res;
        }

        /// <summary>
        /// Create a new shopping list
        /// </summary>
        /// <param name="request">The shopping list to create</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ShoppingList> CreateShoppingList([FromBody] ShoppingListRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var shoppingList = new ShoppingList
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            return _service.AddList(shoppingList);
        }

        /// <summary>
        /// Update a shopping list. This does not modify the items.
        /// </summary>
        /// <param name="listId">The id of the list to update</param>
        /// <param name="request">The new list</param>
        /// <returns></returns>
        [HttpPut("{listId}")]
        public ActionResult<ShoppingList> UpdateShoppingList([FromRoute] Guid listId, [FromBody] ShoppingListRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var shoppingList = new ShoppingList
            {
                Id = listId,
                Name = request.Name
            };

            var res = _service.UpdateList(shoppingList);

            if (res == null)
                return NotFound();

            return res;
        }

        /// <summary>
        /// Delete a specified shopping list
        /// </summary>
        /// <param name="listId">The list to delete</param>
        /// <returns></returns>
        [HttpDelete("{listId}")]
        public ActionResult DeleteList([FromRoute] Guid listId)
        {
            var res = _service.DeleteList(listId);

            if (res) return Ok();
            else return NotFound();
        }


        // Item operations

        /// <summary>
        /// Get a specified item of a specified list
        /// </summary>
        /// <param name="listId">The id of the list of the item</param>
        /// <param name="id">The id of the item to get</param>
        /// <returns></returns>
        [HttpGet("{listId}/items/{id}")]
        public ActionResult<ShoppingItem> GetItem([FromRoute] Guid listId, [FromRoute] Guid id)
        {
            var res = _service.GetItem(listId, id);

            if (res == null)
                return NotFound();

            return res;
        }

        /// <summary>
        /// Add a new item to specified list
        /// </summary>
        /// <param name="listId">The id of the list to add to</param>
        /// <param name="request">The item to add</param>
        /// <returns></returns>
        [HttpPost("{listId}")]
        public ActionResult<ShoppingItem> CreateItem([FromRoute] Guid listId, [FromBody] ShoppingItemRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var shoppingItem = new ShoppingItem
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Checked = request.Checked
            };

            var res = _service.AddItem(listId, shoppingItem);

            if (res == null)
                return NotFound();

            return res;
        }

        /// <summary>
        /// Update a specified item of a specified list
        /// </summary>
        /// <param name="listId">The id of the list of the item</param>
        /// <param name="Id">The id of the item</param>
        /// <param name="request">The new item</param>
        /// <returns></returns>
        [HttpPut("{listId}/items/{id}")]
        public ActionResult<ShoppingItem> UpdateItem([FromRoute] Guid listId, [FromRoute] Guid Id, [FromBody] ShoppingItemRequest request)
        {
            var shoppingItem = new ShoppingItem
            {
                Id = Id,
                Description = request.Description,
                Checked = request.Checked
            };

            var res = _service.UpdateItem(listId, shoppingItem);

            if (res == null)
                return NotFound();

            return res;
        }

        /// <summary>
        /// Delete an item of a specified list
        /// </summary>
        /// <param name="listId">The id of the list of the item</param>
        /// <param name="Id">The id of the item to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{listId}/items/{id}")]
        public ActionResult DeleteItem([FromRoute] Guid listId, [FromRoute] Guid Id)
        {
            var res = _service.DeleteItem(listId, Id);

            if (res) return Ok();
            else return NotFound();
        }
    }
}