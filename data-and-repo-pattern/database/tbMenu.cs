using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.database
{
    [Table("tbMenu")]
    public class tbMenu
    {
        [Key]
        public int MenuId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
    }
}
