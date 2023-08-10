using FetchFood.UseCases.DTOs;
using FetchFood.UseCases.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FetchFood.WebApi.Controllers.Restaurant
{
    [ApiController]
    [Route("api/restaurant")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadItemDto> GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadItemDto>> GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] CreateItemDto createItemDto)
        {
            ReadItemDto itemDto = _itemService.CreateItem(createItemDto);
            return CreatedAtAction(nameof(GetItemById), new { id = itemDto.Id }, itemDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] UpdateItemDto updateItemDto)
        {
            bool isUpdated = _itemService.UpdateItem(id, updateItemDto);
            if (isUpdated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteItem(int id)
        {
            bool isDeleted = _itemService.DeleteItem(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
