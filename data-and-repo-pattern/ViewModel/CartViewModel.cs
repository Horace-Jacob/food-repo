using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.ViewModel
{
    public class CartViewModel
    {
        public int? id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public int? Subtotal { get; set; }
        public int? Price { get; set; }
    }
}
