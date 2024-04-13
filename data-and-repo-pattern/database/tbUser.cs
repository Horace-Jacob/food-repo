using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.database
{
    [Table("tbUser")]
    public class tbUser
    {
        [Key]
        public int UserID { get; set; }
        public string? Username { get; set; }
    }
}
