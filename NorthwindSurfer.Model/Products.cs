using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindSurfer.Model
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? QuantityPerUNit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitslnStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public int? Discontinued { get; set; }

        public Categories Category { get; set; }
    }
}
