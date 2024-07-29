using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanPhamClassLiBrary.Model;

namespace SanPhamClassLiBrary
{
    public static class DataReaderExtensions
    {
        public static List<T> ConvertDataReaderToList<T>(this SqlDataReader reader, Func<IDataRecord, T> mapFunc)
        {
            var list = new List<T>();
            while (reader.Read())
            {
                var item = mapFunc(reader);
                list.Add(item);
            }
            return list;
        }
    }


    public static class ProductMapper
    {
        public static ProductModel MapToProductModel(IDataRecord record)
        {
            return new ProductModel
            {
                Id = record.GetInt32(record.GetOrdinal("Id")),
                Name = record.GetString(record.GetOrdinal("Name")),
                Description = record.GetString(record.GetOrdinal("Description")),
                IsActive = record.GetString(record.GetOrdinal("StatusDescription")),
                Price = record.GetInt32(record.GetOrdinal("Price"))
            };
        }
    }
}
