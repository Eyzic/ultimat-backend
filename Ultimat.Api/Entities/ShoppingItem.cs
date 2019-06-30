using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ultimat.Api.Entities
{
    public class ShoppingItem
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
    }
}
