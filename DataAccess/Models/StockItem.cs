using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StockItem
    {
        public StockItem()
        {
            StockAccessories = new HashSet<StockAccessory>();
            StockImages = new HashSet<StockImage>();
        }

        public int StockItemId { get; set; }
        public string? RegNo { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? ModelYear { get; set; }
        public string? Kms { get; set; }
        public string? Colour { get; set; }
        public string? Vin { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public DateTime? Dtcreated { get; set; }
        public DateTime? Dtupdated { get; set; }

        public virtual ICollection<StockAccessory> StockAccessories { get; set; }
        public virtual ICollection<StockImage> StockImages { get; set; }
    }
}
