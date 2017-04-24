using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPlayGroundTestData.DataLayer;

namespace EFPlayGroundTestData.Context
{
    public class ShopDataContext : DbContext
    {
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}
