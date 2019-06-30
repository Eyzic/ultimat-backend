using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ultimat.Api.Entities.Requests
{
    public class ShoppingListRequest
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
