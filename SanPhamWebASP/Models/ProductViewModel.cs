using SanPhamClassLiBrary.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SanPhamWebASP.Models
{
    public class ProductViewModel
    {
      /*  Action meth*/
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public int Price { get; set; }

       
    }
}