﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Car_Stock_Management.Models
{
    public partial class StockAccessory
    {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? StockItemId { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}