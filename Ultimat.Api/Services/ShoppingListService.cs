using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ultimat.Api.Entities;
using Ultimat.Api.Repositories;

namespace Ultimat.Api.Services
{
    public class ShoppingListService : IShoppingListService
    {

        private readonly IShoppingListRepository _repository;
        public ShoppingListService(IShoppingListRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ShoppingList> GetAllLists() { return _repository.GetAllLists(); }
        public ShoppingListWithItems GetList(Guid id) { return _repository.GetList(id); }
        public ShoppingList AddList(ShoppingList list) { return _repository.SaveList(list); }
        public ShoppingList UpdateList(ShoppingList list) { return _repository.UpdateList(list); }
        public bool DeleteList(Guid id) { return _repository.DeleteList(id); }

        public ShoppingItem GetItem(Guid listId, Guid id) { return _repository.GetItem(listId, id); }
        public ShoppingItem AddItem(Guid listId, ShoppingItem item) { return _repository.SaveItem(listId, item); }
        public ShoppingItem UpdateItem(Guid listId, ShoppingItem item) { return _repository.UpdateItem(listId, item); }
        public bool DeleteItem(Guid listId, Guid id) { return _repository.DeleteItem(listId, id); }

    }
}
