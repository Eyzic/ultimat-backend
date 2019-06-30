using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ultimat.Api.Entities.Requests
{
    public class ShoppingItemRequest
    {
        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        public bool Checked { get; set; } = false;
    }
}
