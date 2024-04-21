using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_and_repo_pattern.ViewModel
{
    public class UserViewModel
    {
        public string? status { get; set; }
        public string? token { get; set; }
        public int? userid { get; set; }
        public string? Role { get; set; }
    }
}
