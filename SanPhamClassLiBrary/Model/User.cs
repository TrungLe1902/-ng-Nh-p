using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPhamClassLiBrary.Model
{

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public bool IsAdmin { get; set; }
        public string Address { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public string CreatedUser { get; set; }
    }

}
