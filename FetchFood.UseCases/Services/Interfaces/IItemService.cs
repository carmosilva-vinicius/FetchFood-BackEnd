using FetchFood.UseCases.DTOs;

namespace FetchFood.UseCases.Services.Interfaces
{
    public interface IItemService
    {
        IEnumerable<ReadItemDto>? GetItems();
        ReadItemDto? GetItemById(int id);
        ReadItemDto CreateItem(CreateItemDto createItemDto);
        bool UpdateItem(int id, UpdateItemDto updateItemDto);
        bool DeleteItem(int id);
    }
}
