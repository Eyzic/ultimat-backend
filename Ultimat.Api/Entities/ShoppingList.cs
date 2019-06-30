using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ultimat.Api.Entities
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ShoppingListWithItems : ShoppingList
    {
        public IEnumerable<ShoppingItem> Items { get; set; }
    }
}
