using System;
using System.Collections.Generic;

namespace ACM.BL.BusinessObjects
{
    public class OrderRepository
    {
        /// <summary>
        /// Retrieve one Order
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Order Retrieve(int orderId)
        {
            Order order = new Order(orderId);

            // TODO: Logic to get the actual Order

            if (order.OrderId == 10)
            {
                order.OrderDate = new DateTimeOffset(2014, 11, 20, 14, 49, 00, new TimeSpan(-5));
            }
            return order;
        }

        public OrderDisplay RetrieveOrderDisplay(int orderId)
        {
            OrderDisplay orderDisplay = new OrderDisplay();

            // TODO: Logic to get actual Order

            if (orderId == 10)
            {
                orderDisplay.FirstName = "Bilbo";
                orderDisplay.LastName = "Baggins";
                orderDisplay.OrderDate = new DateTimeOffset(2014, 4, 14, 10, 00, 00, new TimeSpan(5,0,0));
                orderDisplay.ShippingAddress = new Address() 
                { 
                    AddressType = 1,
                    StreetLine1 = "Bag End",
                    City = "Hobbiton",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "144"
                };
            }

            orderDisplay.OrderDisplayItemList = new List<OrderDisplayItem>();
            // TODO: Logic to get actual OrderItem

            if (orderId == 10)
            {
                var orderDisplayItem = new OrderDisplayItem()
                {
                    ProductName = "Sunflowers",
                    PurchasePrice = 15.96M,
                    OrderQuantity = 2
                };
                orderDisplay.OrderDisplayItemList.Add(orderDisplayItem);
                orderDisplayItem = new OrderDisplayItem()
                {
                    ProductName = "Rake",
                    PurchasePrice = 6M,
                    OrderQuantity = 1
                };
                orderDisplay.OrderDisplayItemList.Add(orderDisplayItem);
            }
            return orderDisplay;
        }

        public List<Order> Retrieve()
        {
            return new List<Order>();
        }
        /// <summary>
        /// Saves current Order
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined Order
            return true;
        }


    }
}
