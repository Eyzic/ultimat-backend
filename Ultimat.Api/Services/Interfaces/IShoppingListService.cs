using System;
using System.Collections.Generic;
using Ultimat.Api.Entities;

namespace Ultimat.Api.Services
{
    public interface IShoppingListService
    {
        IEnumerable<ShoppingList> GetAllLists();
        ShoppingListWithItems GetList(Guid id);
        ShoppingList AddList(ShoppingList list);
        ShoppingList UpdateList(ShoppingList list);
        Boolean DeleteList(Guid id);

        ShoppingItem GetItem(Guid listId, Guid id);
        ShoppingItem AddItem(Guid listId, ShoppingItem item);
        ShoppingItem UpdateItem(Guid listId, ShoppingItem item);
        Boolean DeleteItem(Guid listId, Guid id);
    }
}