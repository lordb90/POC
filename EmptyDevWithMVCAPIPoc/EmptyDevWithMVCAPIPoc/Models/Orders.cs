using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyDevWithMVCAPIPoc.Models
{
    public class Order
    {
        IEnumerable<OrderLine> Lines;
    }

}