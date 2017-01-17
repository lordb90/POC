using ACM.Common;
using System;
using System.Collections.Generic;

namespace ACM.BL.BusinessObjects
{
    public class Order : EntityBase, ILoggable
    {

        public Order()
        {

        }

        public Order(int orderId)
        {
            this.OrderId = orderId;
        }

        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        public List<OrderItem> Orderitems { get; set; }

        public override bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) isValid = false;

            return isValid;
        }

        public string Log()
        {
            var logString = this.OrderId + ": " +
                            "Date: " + this.OrderDate.Value.Date + " " +
                            "Status: " + this.EntityState.ToString();
            return logString;
        }
    }
}
