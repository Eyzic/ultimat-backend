using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultimat.Api.Entities;

namespace Ultimat.Api.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        // Temporary dictionaries as databases for the initial demo. TODO: change to real databases later
        private Dictionary<Guid, ShoppingList> listDatabase; // Map of shopping lists by their key
        private Dictionary<Guid, ShoppingItem> itemDatabase; // Map of shopping items by their key
        private Dictionary<Guid, List<Guid>> itemsInList; // Map of shopping item ids by list id

        public ShoppingListRepository()
        {
            listDatabase = new Dictionary<Guid, ShoppingList>();
            itemDatabase = new Dictionary<Guid, ShoppingItem>();
            itemsInList = new Dictionary<Guid, List<Guid>>();
        }

        // List operations
        public IEnumerable<ShoppingList> GetAllLists()
        {
            return listDatabase.Values;
        }

        public ShoppingListWithItems GetList(Guid id)
        {
            if (listDatabase.ContainsKey(id))
            {
                var listWithoutItems = listDatabase[id];
                var itemIds = itemsInList[id];

                var items = itemIds.Select(itemId => itemDatabase[itemId]);

                return new ShoppingListWithItems
                {
                    Id = listWithoutItems.Id,
                    Name = listWithoutItems.Name,
                    Items = items
                };
            }
            else { return null; }
        }

        public ShoppingList SaveList(ShoppingList list)
        {
            listDatabase.Add(list.Id, list);
            itemsInList.Add(list.Id, new List<Guid>());
            return list;
        }

        public ShoppingList UpdateList(ShoppingList list)
        {
            if (listDatabase.ContainsKey(list.Id))
            {
                listDatabase[list.Id] = list;
                return list;
            }
            else { return null; }
        }

        public bool DeleteList(Guid id)
        {
            if (listDatabase.ContainsKey(id))
            {
                itemsInList[id].ForEach(itemId => itemDatabase.Remove(itemId));
                listDatabase.Remove(id);
                itemsInList.Remove(id);
                return true;
            }
            return false;
        }



        // Item operations
        public ShoppingItem GetItem(Guid listId, Guid id)
        {
            if (itemDatabase.ContainsKey(id)) return itemDatabase[id];
            else return null;
        }

        public ShoppingItem SaveItem(Guid listId, ShoppingItem item)
        {
            if (listDatabase.ContainsKey(listId))
            {
                itemDatabase.Add(item.Id, item);
                itemsInList[listId].Add(item.Id);
                return item;
            }
            else { return null; }
        }

        public ShoppingItem UpdateItem(Guid listId, ShoppingItem item)
        {
            if (itemDatabase.ContainsKey(item.Id))
            {
                itemDatabase[item.Id] = item;
                return item;
            }
            else { return null; }
        }

        public bool DeleteItem(Guid listId, Guid id)
        {
            if (itemDatabase.ContainsKey(id))
            {
                itemDatabase.Remove(id);
                itemsInList[listId].Remove(id);

                return true;
            }
            return false;
        }
    }
}
