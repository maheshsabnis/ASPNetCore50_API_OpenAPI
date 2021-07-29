using System;
using System.Collections.Generic;

#nullable disable

namespace Service_API.Models
{
    public partial class ProductsInfo
    {
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
    }
}
