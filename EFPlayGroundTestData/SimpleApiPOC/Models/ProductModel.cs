using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApiPOC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
    }    
}