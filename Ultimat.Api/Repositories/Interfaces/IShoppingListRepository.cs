using System;
using System.Collections.Generic;
using Ultimat.Api.Entities;

namespace Ultimat.Api.Repositories
{
    public interface IShoppingListRepository
    {
        IEnumerable<ShoppingList> GetAllLists();
        ShoppingListWithItems GetList(Guid id);
        ShoppingList SaveList(ShoppingList list);
        ShoppingList UpdateList(ShoppingList list);
        Boolean DeleteList(Guid id);

        ShoppingItem GetItem(Guid listId, Guid id);
        ShoppingItem SaveItem(Guid listId, ShoppingItem item);
        ShoppingItem UpdateItem(Guid listId, ShoppingItem item);
        Boolean DeleteItem(Guid listId, Guid id);
    }
}