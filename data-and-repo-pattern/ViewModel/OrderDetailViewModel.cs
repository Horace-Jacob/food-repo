using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.ViewModel
{
    public class OrderDetailViewModel
    {
        public string? Name { get; set; }
        public int? Phone { get; set; } 
        public string? Address { get; set; }
        public DateTime Time { get; set; }
        public string? OrderItem { get; set; }
        public int? Price { get; set; }
        public string? Status { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
    }
}
