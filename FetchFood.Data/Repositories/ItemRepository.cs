using FetchFood.Data.Context;
using FetchFood.Entities;
using FetchFood.Entities.Interfaces;

namespace FetchFood.Data.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        public FetchFoodDbContext _context;

        public ItemRepository(FetchFoodDbContext context)
        {
            _context = context;
        }

        public void CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }


        public Item? GetItemById(int id)
        {
            Item? item = _context.Items.Find(id);
            return item;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public void UpdateItem(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }
}
