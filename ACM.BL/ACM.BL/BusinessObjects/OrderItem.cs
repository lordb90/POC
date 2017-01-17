using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BL.BusinessObjects
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            this.OrderItemId = orderItemId;
        }

        public int OrderItemId { get; private set; }
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// Retrieve one OrderItem
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public OrderItem Retrieve(int orderItemId)
        {
            // Code retrieves the defined OrderItem
            return new OrderItem();
        }

        public List<OrderItem> Retrieve()
        {
            return new List<OrderItem>();
        }
        /// <summary>
        /// Saves current OrderItem
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined OrderItem
            return true;
        }

        public bool Validate()
        {
            var isValid = true;
            if (OrderQuantity <= 0) isValid = false;
            if (ProductId <= 0) isValid = false;
            if (PurchasePrice == null) isValid = false;

            return isValid;
        }
    }

}
