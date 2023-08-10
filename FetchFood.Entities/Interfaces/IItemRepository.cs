using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Entities.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item? GetItemById(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item); 
        void DeleteItem(Item item);
    }
}
