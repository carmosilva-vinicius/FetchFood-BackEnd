using AutoMapper;
using FetchFood.Entities;
using FetchFood.Entities.Interfaces;
using FetchFood.UseCases.DTOs;
using FetchFood.UseCases.Services.Interfaces;

namespace FetchFood.UseCases.Services
{
    public class ItemService : IItemService
    {
        private IMapper _mapper;
        public IItemRepository _itemRespository;

        public ItemService(IMapper mapper, IItemRepository itemRespository)
        {
            _mapper = mapper;
            _itemRespository = itemRespository;
        }

        public IEnumerable<ReadItemDto>? GetItems()
        {
            IEnumerable<Item> items = _itemRespository.GetItems();
            if (items != null)
            {
                var itemsDto = _mapper.Map<IEnumerable<ReadItemDto>>(items);
                return itemsDto;
            }
            return null;
        }

        public ReadItemDto CreateItem(CreateItemDto createItemDto)
        {
            var item = _mapper.Map<Item>(createItemDto);
            _itemRespository.CreateItem(item);
            var itemDto = _mapper.Map<ReadItemDto>(item);
            return itemDto;
        }

        public ReadItemDto? GetItemById(int id)
        {
            var item = _itemRespository.GetItemById(id);
            if (item != null)
            {
                var itemDto = _mapper.Map<ReadItemDto>(item);
                return itemDto;
            }
            return null;
        }

        public bool UpdateItem(int id, UpdateItemDto updateItemDto)
        {
            var item = _itemRespository.GetItemById(id);
            if (item != null)
            {
                _mapper.Map(updateItemDto, item);
                _itemRespository.UpdateItem(item);
                return true;
            }
            return false;
        }
        public bool DeleteItem(int id)
        {
            var item = _itemRespository.GetItemById(id);
            if (item != null)
            {
                _itemRespository.DeleteItem(item);
                return true;
            }
            return false;
        }
    }
}
