using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.database
{
    [Table("tbOrder")]
    public class tbOrder
    {
        [Key]
        public int OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }
        public int? Price { get; set; }
        public DateTime Time { get; set; }
        public int UserID { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
