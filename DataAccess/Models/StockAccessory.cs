using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StockAccessory
    {
        public int AccessoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? StockItemId { get; set; }

        public virtual StockItem? StockItem { get; set; }
    }
}
