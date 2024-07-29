using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPhamClassLiBrary.Model
{
    public class ProductModel
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public int Price { get; set; }
        public static ProductModel FromDataReader(IDataReader reader)
        {
            return new ProductModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                IsActive = reader.GetString(reader.GetOrdinal("StatusDescription")),
                Price = reader.GetInt32(reader.GetOrdinal("Price"))
            };
        }
    }
   
}
