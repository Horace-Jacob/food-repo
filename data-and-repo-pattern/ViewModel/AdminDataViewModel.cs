using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.ViewModel
{
    public class AdminDataViewModel
    {
        public int? TotalMenu { get; set; }
        public int? PendingOrder { get; set; } 
        public int? DeliveredOrder { get; set; }
        public int? TotalUsers { get; set; }
    }
}
