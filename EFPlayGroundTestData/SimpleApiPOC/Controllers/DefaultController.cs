using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EFPlayGroundTestData.Context;
using SimpleApiPOC.Models;

namespace SimpleApiPOC.Controllers
{
    public class DefaultController : ApiController
    {

        [ResponseType(typeof(ProductModel))]
        public async Task<List<ProductModel>> Get(string category)
        {
            using (var context = new ShopDataContext())
            {
                return context.Products.Where(x => x.Category.Name == category)
                    .Select(x => 
                        new ProductModel 
                        {  
                            Id = x.Id,
                            CategoryName = x.Category.Name,
                            Price = x.Name.StartsWith("P") ? x.Price * 0.5 : x.Price,
                            Name = x.Name
                        })
                    .ToList();
            }
        }
    }
}
